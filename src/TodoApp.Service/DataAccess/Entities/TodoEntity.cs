namespace TodoApp.Service.DataAccess;

public class TodoEntity : Entity<Guid>
{
    public string Title { get; set; }

    public bool Done { get; set; }
}
