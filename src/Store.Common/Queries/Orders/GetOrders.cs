using Common.Monad;
using MediatR;
using Store.Common.Data.Domain;

public sealed class GetOrders : IRequest<Either<Fail, Order[]>> { }