using Microsoft.AspNetCore.Mvc;
using Shared.Models;


namespace Server.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
private static readonly List<TodoItem> Items = new()
{
new TodoItem { Id = 1, Title = "Criar scaffold", Done = false },
new TodoItem { Id = 2, Title = "Usar MudBlazor", Done = true }
};


[HttpGet]
public ActionResult<List<TodoItem>> Get() => Items;


[HttpPost]
public ActionResult<TodoItem> Create(TodoItem item)
{
item.Id = Items.Max(x => x.Id) + 1;
Items.Add(item);
return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
}
}
