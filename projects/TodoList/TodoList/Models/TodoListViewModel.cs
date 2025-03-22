namespace TodoList.Models
{
    public class TodoListViewModel
    {
        public required IEnumerable<TodoItem> items { get; init; }
    }
}
