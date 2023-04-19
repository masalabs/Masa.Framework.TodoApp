namespace TodoApp.Service.Application.Commands;

public record CreateTodoCommand(TodoCreateUpdateDto Dto) : Command { }
