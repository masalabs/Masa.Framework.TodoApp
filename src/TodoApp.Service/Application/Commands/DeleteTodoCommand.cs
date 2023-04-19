namespace TodoApp.Service.Application.Commands;

public record DeleteTodoCommand(Guid Id) : Command { }
