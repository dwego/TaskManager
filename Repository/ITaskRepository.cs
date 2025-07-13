namespace TaskManager.Repository;

public interface ITaskRepository
{
    void Save(Task task);
    Task FindById(int id);
    Task[] GetAll();
    void Delete(Task task);
}