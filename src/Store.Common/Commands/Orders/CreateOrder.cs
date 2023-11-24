using Common.Monad;
using MediatR;
using Store.Common.Data.Domain;

namespace Store.Common.Commands.Orders
{
    public sealed class CreateOrder : IRequest<Either<Fail, Order>>
    {
        public string Description { get; set; }
    }
}
