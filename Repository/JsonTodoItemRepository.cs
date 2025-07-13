using System.Text.Json;
using TaskManager.Model;

namespace TaskManager.Repository;

public class JsonTodoItemRepository : ITodoItemRepository
{
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };
    public JsonTodoItemRepository(string filePath = "tasks.json")
    {
        _filePath = filePath;
    }
    public void Save(TodoItem todoItem)
    {
        var items = GetAll().ToList();
        var existing = items.FirstOrDefault(x => x.Id == todoItem.Id);

        if (existing != null)
            items[items.IndexOf(existing)] = todoItem;
        else
        {
            todoItem.Id = items.Count > 0 ? items.Max(x => x.Id) + 1 : 1;
            items.Add(todoItem);
        }

        File.WriteAllText(_filePath, JsonSerializer.Serialize(items, _jsonOptions));
    }
    
    public TodoItem? FindById(int id)
    {
        return GetAll().FirstOrDefault(x => x.Id == id);
    }
    
    public TodoItem[] GetAll()
    {
        if (!File.Exists(_filePath))
            return Array.Empty<TodoItem>();

        var json = File.ReadAllText(_filePath);
        return string.IsNullOrEmpty(json) 
            ? Array.Empty<TodoItem>() 
            : JsonSerializer.Deserialize<TodoItem[]>(json, _jsonOptions) ?? Array.Empty<TodoItem>();
    }
    
    public void Delete(TodoItem todoItem)
    {
        var items = GetAll().Where(x => x.Id != todoItem.Id).ToArray();
        File.WriteAllText(_filePath, JsonSerializer.Serialize(items, _jsonOptions));
    }
}