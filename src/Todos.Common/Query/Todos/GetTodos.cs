using Common.Monad;
using MediatR;
using Todos.Common.Data.Domain;

namespace Todos.Common.Query.Todos
{
    public sealed class GetTodos : IRequest<Either<Fail, Todo[]>>
    {
    }
}
