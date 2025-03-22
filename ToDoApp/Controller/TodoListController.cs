using Microsoft.AspNetCore.Mvc;
using ToDoApp.Model;
using ToDoApp.Service;

namespace ToDoApp.Controller;
    
[Route("api/[controller]")]
[Controller]
public class TodoListController :ControllerBase
{
    private readonly TodoListService _todoListService;
    public TodoListController(TodoListService todoListService)
    {
        _todoListService = todoListService;
    }

    [HttpPost]
    public async Task<ActionResult> Insert([FromBody]TodoList todoList)
    {
        var result = await _todoListService.insert(todoList);
        if(result != null)
        {
            return Ok(result);
        }

        return BadRequest();
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var result = await _todoListService.GetAll();
        if (result != null)
        {
            return Ok(result);
        }

        return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(string id)
    {
        var result = await _todoListService.GetById(id);
        if (result != null)
        {
            return Ok(result);
        }

        return NotFound();
    }
    [HttpPut]
    public async Task<ActionResult> Update([FromBody]TodoList todoList)
    {
        var result = await _todoListService.Update(todoList);
        if (result != null)
        {
            return Ok(result);
        }

        return NotFound();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        await _todoListService.Remove(id);
        return Ok();
    }
}