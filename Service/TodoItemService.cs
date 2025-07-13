using TaskManager.Model;
using TaskManager.Repository;

namespace todoItemManager.Service;

public class TodoItemService
{
    private readonly ITodoItemRepository _todoItemRepository;
    
    public TodoItemService(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }
    
    public void Add(string description)
    {
        TodoItem todoItem = TodoItemBuilder
            .Create()
            .WithDescription(description)
            .Build();
        
        _todoItemRepository.Save(todoItem);
    }
    
    public TodoItem[] GetAll()
    {
        return _todoItemRepository.GetAll();
    }
    
    public TodoItem SetDone(int id)
    {
        var todoItem = GetById(id);
        
        todoItem.Done = true;
        _todoItemRepository.Save(todoItem);
        
        return todoItem;
    }
    
    public void Delete(int id)
    {
        var todoItem = GetById(id);
        _todoItemRepository.Delete(todoItem);
    }

    private TodoItem GetById(int id)
    {
        return _todoItemRepository.FindById(id) ?? throw new ArgumentException($"Item with id {id} not found");
    }
}