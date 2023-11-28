using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todos.Common.Data.Domain;
using Todos.Common.Query.Todos;
using Todos.MVC.Models;

namespace Todos.MVC.Pages.Items
{
    public class IndexModel(IMediator mediator) : PageModel
    {
        private readonly IMediator _mediator = mediator;

        public IEnumerable<TodoViewModel> Todos { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var result = await _mediator.Send(new GetTodos()).ConfigureAwait(false);

            Todos = result.ReduceTo(
                f => Todos = Array.Empty<TodoViewModel>(),
                s => s.Select(x => new TodoViewModel
                {
                    Todo = new Todo
                    {
                        Completed = x.Completed,
                        Description = x.Description,
                        Id = x.Id,
                    },
                    ShowViewButton = true
                }));

            return Page();
        }
    }
}