using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Todos.MVC.Models;

namespace Todos.MVC.Pages.Items
{
    [Authorize]
    public class IndexModel(IHttpClientFactory factory) : PageModel
    {
        private readonly IHttpClientFactory _factory = factory;

        public TodosContainer Container { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var httpClient = _factory.CreateClient();
            var response = await httpClient.GetAsync("https://dummyjson.com/todos").ConfigureAwait(false);
            var todosJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            Container = JsonConvert.DeserializeObject<TodosContainer>(todosJson);

            return Page();
        }
    }
}