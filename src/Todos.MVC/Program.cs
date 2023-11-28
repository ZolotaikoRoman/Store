using Common.Services.Mediatr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Todos.Common.Data;
using Todos.Common.Data.Domain;
using Todos.Common.Query.Todos;
using Todos.Common.Services.Handlers.Todos;
using Todos.MVC.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddDbContext<TodoContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("TodoDbConnection")));

builder.Services.ConfigureIdentity();

builder.Services.AddScoped<IMediator, Mediator>();
builder.Services.ForScoped<GetTodos, Todo[]>().AddHandler<GetTodosHandler>();
builder.Services.ForScoped<GetTodo, Todo>().AddHandler<GetTodoHandler>();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSerilogRequestLogging();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();