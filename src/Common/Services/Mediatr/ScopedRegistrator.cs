using Common.Monad;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Services.Mediatr
{
    public static class ScopedRegistrator
    {
        public static Scope<TRequest, TResponse> ForScoped<TRequest, TResponse>(this IServiceCollection services)
            where TRequest : IRequest<Either<Fail, TResponse>>
        {
            return new Scope<TRequest, TResponse>(services);
        }
    }
}