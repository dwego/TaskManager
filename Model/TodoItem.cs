namespace TaskManager.Model;

public class TodoItem
{
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public bool Done { get; set; }
}

public class TodoItemBuilder
{
    private readonly TodoItem _todoItem = new TodoItem();

    public static TodoItemBuilder Create() => new TodoItemBuilder();

    public TodoItemBuilder WithDescription(string description)
    {
        _todoItem.Description = description;
        return this;
    }

    public TodoItem Build()
    {
        return _todoItem;
    }
}