using Common.Monad;
using MediatR;
using Todos.Common.Data.Domain;

namespace Todos.Common.Query.Todos
{
    public sealed class GetTodo : IRequest<Either<Fail, Todo>>
    {
        public Guid Id { get; set; }
    }
}
