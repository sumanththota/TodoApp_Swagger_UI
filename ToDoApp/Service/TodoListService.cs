using MongoDB.Bson;
using MongoDB.Driver;
using ToDoApp.Model;

namespace ToDoApp.Service;

public class TodoListService
{
    private readonly IMongoCollection<TodoList> _collection;

    public TodoListService(IDatabaseSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.Database);
        _collection = database.GetCollection<TodoList>(nameof(TodoList));
    }

    public async Task<TodoList> insert(TodoList todoList)
    {
        await _collection.InsertOneAsync(todoList);
        return todoList;
    }

    public async Task<TodoList> Update(TodoList todoList)
    {
        await _collection.ReplaceOneAsync(x => x.Id == todoList.Id, todoList);
        return todoList;
    }
    public async Task<IList<TodoList>> GetAll() //Read
    {
        return await _collection.FindAsync(new BsonDocument()).Result.ToListAsync();
    }
    public async Task<TodoList> GetById(string todoListId)
    {
        return await _collection.Find(x => x.Id == todoListId).FirstOrDefaultAsync();
    }
    public async Task Remove(string todoListId)
    {
        await _collection.DeleteOneAsync(x => x.Id == todoListId);
    }
   
    
}