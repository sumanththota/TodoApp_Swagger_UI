using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace ToDoApp.Domain;

public class TodoList
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [SwaggerSchema(ReadOnly = true)]
    public string Id { get; set; } 
    
    public string Name { get; set; }
    
    public IList<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}