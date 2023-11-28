using Microsoft.EntityFrameworkCore;
using Todos.Common.Data.Configuration;
using Todos.Common.Data.Domain;

namespace Todos.Common.Data
{
    public sealed class TodoContext(DbContextOptions<TodoContext> options) : DbContext(options)
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TodoConfiguration());
        }
    }
}