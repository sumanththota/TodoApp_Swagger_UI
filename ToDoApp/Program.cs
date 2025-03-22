using Microsoft.Extensions.Options;
using ToDoApp;
using ToDoApp.Service;

var builder = WebApplication.CreateBuilder(args);

// Configure MongoDB settings and register services
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddSingleton<IDatabaseSettings>(x => 
    x.GetRequiredService<IOptions<DatabaseSettings>>().Value);
builder.Services.AddScoped<TodoListService>();

// Register controllers
builder.Services.AddControllers();

// Add Swagger/OpenAPI services if needed
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware for development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Map controller endpoints (this makes your TodoListController accessible)
app.MapControllers();

app.Run();