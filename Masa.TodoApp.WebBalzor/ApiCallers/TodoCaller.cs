using Masa.Contrib.Service.Caller.HttpClient;
using Masa.TodoApp.Contracts;
using Microsoft.Extensions.Options;

namespace Masa.TodoApp.WebBalzor.ApiCallers;

public class TodoCaller : HttpClientCallerBase
{
    private readonly string _prefix = "/api/v1/todoes";
    protected override string BaseAddress { get; set; }

    public TodoCaller(IOptions<TodoServiceOptions> options)
    {
        BaseAddress = options.Value.BaseAddress;
    }

    public async Task<List<TodoGetListDto>> GetListAsync()
    {
        var result = await Caller.GetAsync<List<TodoGetListDto>>($"{_prefix}/list");
        return result ?? new();
    }

    public async Task CreateAsync(TodoCreateUpdateDto dto)
    {
        var result = await Caller.PostAsync($"{_prefix}", dto);
    }

    public async Task UpdateAsync(Guid id, TodoCreateUpdateDto dto)
    {
        var result = await Caller.PutAsync($"{_prefix}/{id}", dto);
    }

    public async Task DeleteAsync(Guid id)
    {
        var result = await Caller.DeleteAsync($"{_prefix}/{id}", null);
    }

    public async Task DoneAsync(Guid id, bool done)
    {
        var result = await Caller.PostAsync($"{_prefix}/done?id={id}&done={done.ToString().ToLower()}", null);
    }
}
