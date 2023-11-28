using Todos.Common.Data.Domain;

namespace Todos.MVC.Models
{
    public sealed class TodoViewModel
    {
        public bool ShowViewButton { get; set; } = false;

        public Todo Todo { get; set; }
    }
}
