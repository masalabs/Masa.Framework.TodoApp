namespace TodoApp.Service.Application.Commands;

public record DoneTodoCommand(Guid Id, bool Done) : Command { }
