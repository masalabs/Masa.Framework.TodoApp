namespace TodoApp.Service.Application.Queries;

public record TodoGetListQuery : Query<List<TodoGetListDto>>
{
    public override List<TodoGetListDto> Result { get; set; }
}
