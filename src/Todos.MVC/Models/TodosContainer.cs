namespace Todos.MVC.Models
{
    public sealed class TodosContainer
    {
        public IEnumerable<TodoItem> Todos { get; set; }
    }
}