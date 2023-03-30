using Masa.BuildingBlocks.Dispatcher.Events;
using Masa.TodoApp.Contracts;
using Masa.TodoApp.WebApi.Application.Commands;
using Masa.TodoApp.WebApi.Application.Queries;
using Masa.Utils.Models;
using Microsoft.AspNetCore.Mvc;

namespace Masa.TodoApp.WebApi.Services;

public class TodoService : ServiceBase
{
    public TodoService()
    {
        App.MapPost("api/v1/todoes/done", DoneAsync);
    }

    public async Task<List<TodoGetListDto>> GetListAsync(IEventBus eventBus)
    {
        var todoQuery = new TodoGetListQuery();
        await eventBus.PublishAsync(todoQuery);
        return todoQuery.Result;
    }

    public async Task CreateAsync(IEventBus eventBus, TodoCreateUpdateDto dto)
    {
        var command = new CreateTodoCommand(dto);
        await eventBus.PublishAsync(command);
    }

    public async Task UpdateAsync(IEventBus eventBus, Guid id, TodoCreateUpdateDto dto)
    {
        var command = new UpdateTodoCommand(id, dto);
        await eventBus.PublishAsync(command);
    }

    public async Task DeleteAsync(IEventBus eventBus, Guid id)
    {
        var command = new DeleteTodoCommand(id);
        await eventBus.PublishAsync(command);
    }

    public async Task DoneAsync(IEventBus eventBus, [FromQuery] Guid id, [FromQuery] bool done)
    {
        var command = new DoneTodoCommand(id, done);
        await eventBus.PublishAsync(command);
    }
}
