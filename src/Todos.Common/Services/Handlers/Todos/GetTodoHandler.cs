using Common.Monad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Todos.Common.Data;
using Todos.Common.Data.Domain;
using Todos.Common.Query.Todos;

namespace Todos.Common.Services.Handlers.Todos
{
    public sealed class GetTodoHandler(TodoContext context) : IRequestHandler<GetTodo, Either<Fail, Todo>>
    {
        private readonly TodoContext _context = context;

        public async Task<Either<Fail, Todo>> Handle(GetTodo request, CancellationToken cancellationToken)
        {
            return await _context.Todos.SingleAsync(t => t.Id == request.Id).ConfigureAwait(false);
        }
    }
}