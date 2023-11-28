using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Todos.Common.Query.Todos;
using Todos.MVC.Models;

namespace Todos.MVC.Pages.Item
{
    public class ItemModel(IMediator mediator) : PageModel
    {
        private readonly IMediator _mediator = mediator;

        [BindProperty(SupportsGet = true)]
        public Guid ItemId { get; set; }

        public TodoViewModel Item { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var result = await _mediator.Send(new GetTodo { Id = ItemId }).ConfigureAwait(false);

            var item = result.ReduceTo(
                f => null,
                s => s);

            Item = new TodoViewModel
            {
                ShowViewButton = false,
                Todo = item,
            };

            return Page();
        }
    }
}