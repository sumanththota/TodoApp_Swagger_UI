namespace ToDoApp.Dto;


public class TodoListCreateDto
{
    public string Name { get; set; }
    public IList<TodoItemCreateDto> TodoItems { get; set; } = new List<TodoItemCreateDto>();
}

public class TodoItemCreateDto
{
    public string Description { get; set; }
    public bool IsComplete { get; set; }
}