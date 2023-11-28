using Common.Monad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Todos.Common.Data;
using Todos.Common.Data.Domain;
using Todos.Common.Query.Todos;

namespace Todos.Common.Services.Handlers.Todos
{
    public sealed class GetTodosHandler(TodoContext context) : IRequestHandler<GetTodos, Either<Fail, Todo[]>>
    {
        private readonly TodoContext _context = context;

        public async Task<Either<Fail, Todo[]>> Handle(GetTodos request, CancellationToken cancellationToken)
        {
            var todos = await _context.Todos.ToArrayAsync(cancellationToken).ConfigureAwait(false);

            return todos;
        }
    }
}