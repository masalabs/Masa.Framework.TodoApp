var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEventBus()
    .AddMasaDbContext<TodoAppDbContext>(opt =>
    {
    opt.UseSqlite();
    })
    .AddMasaMinimalAPIs(option => option.MapHttpMethodsForUnmatched = new string[] { "Post" })
    .AddAutoInject();

builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "TodoAppApp", Version = "v1", Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "TodoAppApp", } });
        foreach (var item in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xml")) options.IncludeXmlComments(item, true);
        options.DocInclusionPredicate((docName, action) => true);
    });

var app = builder.Build();

app.UseMasaExceptionHandler();

app.MapMasaMinimalAPIs();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoAppApp"));

    #region MigrationDb
    using var context = app.Services.CreateScope().ServiceProvider.GetService<TodoAppDbContext>();
    {
        context!.Database.EnsureCreated();
    }
    #endregion
}

app.Run();
