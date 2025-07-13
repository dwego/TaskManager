using TaskManager.Model;

namespace TaskManager.Repository;

public interface ITodoItemRepository
{
    void Save(TodoItem todoItem);
    TodoItem FindById(int id);
    TodoItem[] GetAll();
    void Delete(TodoItem todoItem);
}