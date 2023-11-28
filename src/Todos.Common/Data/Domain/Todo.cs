namespace Todos.Common.Data.Domain
{
    public sealed class Todo
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}
