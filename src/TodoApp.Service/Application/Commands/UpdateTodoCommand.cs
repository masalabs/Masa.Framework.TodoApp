namespace TodoApp.Service.Application.Commands;

public record UpdateTodoCommand(Guid Id, TodoCreateUpdateDto Dto) : Command { }
