using Common.Monad;
using MediatR;
using Store.Common.Commands.Orders;
using Store.Common.Data;
using Store.Common.Data.Domain;

namespace Store.Common.Services.Handlers.Orders
{
    public sealed class CreateOrderHandler(OrdersContext context) : IRequestHandler<CreateOrder, Either<Fail, Order>>
    {
        private readonly OrdersContext _context = context;

        public async Task<Either<Fail, Order>> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            var order = new Order { Description = request.Description };

            _context.Orders.Add(order);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return order;
        }
    }
}