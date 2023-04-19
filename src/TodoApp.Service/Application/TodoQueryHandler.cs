using TodoApp.Service.Application.Queries;

namespace TodoApp.Service.Application;

public class TodoQueryHandler
{
    readonly TodoAppDbContext _todoDbContext;

    public TodoQueryHandler(TodoAppDbContext todoDbContext) => _todoDbContext = todoDbContext;

    [EventHandler]
    public async Task GetListAsync(TodoGetListQuery query)
    {
        var todoDbQuery = _todoDbContext.Set<TodoEntity>().AsNoTracking();
        query.Result = await todoDbQuery.Select(e => e.Adapt<TodoGetListDto>()).ToListAsync();
    }
}
