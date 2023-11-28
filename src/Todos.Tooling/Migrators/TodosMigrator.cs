using Newtonsoft.Json;
using Todos.Common.Data;
using Todos.Common.Data.Domain;

namespace Todos.Tooling.Migrators
{
    public static class TodosMigrator
    {
        public static async Task Migrate(TodoContext context)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://dummyjson.com/todos").ConfigureAwait(false);
            var todosJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var container = JsonConvert.DeserializeObject<TodosContainer>(todosJson);

            var todos = container.Todos.Select(t => new Todo
            {
                Completed = t.Completed,
                Description = t.Todo,
            }).ToArray();

            context.Todos.AddRange(todos);

            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        private class TempTodo
        {
            public int Id { get; set; }

            public string Todo { get; set; }

            public bool Completed { get; set; }

            public int UserId { get; set; }
        }

        private class TodosContainer
        {
            public IEnumerable<TempTodo> Todos { get; set; }
        }
    }
}
