namespace TodoApp.Service.DataAccess;

public class TodoAppDbContext : MasaDbContext
{
    public DbSet<TodoEntity> Todos { get; set; }

    public TodoAppDbContext(MasaDbContextOptions<TodoAppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreatingExecuting(ModelBuilder modelBuilder)
    {
        base.OnModelCreatingExecuting(modelBuilder);
        ConfigEntities(modelBuilder);
    }

    private static void ConfigEntities(ModelBuilder modelBuilder)
    {
        var todoBuilder = modelBuilder.Entity<TodoEntity>();
        todoBuilder.Property(e => e.Title).HasMaxLength(128);
    }
}
