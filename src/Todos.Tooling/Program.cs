using Microsoft.EntityFrameworkCore;
using Todos.Common.Data;
using Todos.Tooling.Migrators;

var todoConnectionString = "Data Source=Vega;Initial Catalog=TodosDB;TrustServerCertificate=True;Integrated Security=True";
var options = new DbContextOptionsBuilder<TodoContext>().UseSqlServer(todoConnectionString).Options;
var context = new TodoContext(options);

await TodosMigrator.Migrate(context).ConfigureAwait(false);

Console.ReadKey();