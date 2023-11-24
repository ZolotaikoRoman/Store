using Common.Monad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Store.Common.Data;
using Store.Common.Data.Domain;

namespace Store.Common.Services.Handlers.Orders
{
    public sealed class GetOrdersHandler(OrdersContext context) : IRequestHandler<GetOrders, Either<Fail, Order[]>>
    {
        private readonly OrdersContext _context = context;

        public async Task<Either<Fail, Order[]>> Handle(GetOrders request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.ToArrayAsync(cancellationToken).ConfigureAwait(false);

            return orders;
        }
    }
}