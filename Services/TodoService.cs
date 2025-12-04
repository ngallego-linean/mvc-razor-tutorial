using tutorial.Models;

namespace tutorial.Services;

public class TodoService
{
    private static readonly List<TodoItem> _todos = new()
    {
        new TodoItem { Id = 1, Title = "Learn ASP.NET Core MVC", IsCompleted = false },
        new TodoItem { Id = 2, Title = "Build a todo list app", IsCompleted = false },
        new TodoItem { Id = 3, Title = "Deploy to production", IsCompleted = false }
    };
    private static int _nextId = 4;

    public List<TodoItem> GetAll() => _todos.OrderByDescending(t => t.CreatedAt).ToList();

    public TodoItem? GetById(int id) => _todos.FirstOrDefault(t => t.Id == id);

    public void Add(TodoItem item)
    {
        item.Id = _nextId++;
        item.CreatedAt = DateTime.Now;
        _todos.Add(item);
    }

    public void ToggleComplete(int id)
    {
        var item = GetById(id);
        if (item != null)
            item.IsCompleted = !item.IsCompleted;
    }

    public void Delete(int id)
    {
        var item = GetById(id);
        if (item != null)
            _todos.Remove(item);
    }
}
