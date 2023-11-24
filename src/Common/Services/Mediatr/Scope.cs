using Common.Monad;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Services.Mediatr
{
    public class Scope<TRequest, TResponse>(IServiceCollection services)
        where TRequest : IRequest<Either<Fail, TResponse>>
    {
        private readonly IServiceCollection _services = services;

        public IServiceCollection Services => _services;

        public void AddHandler<THandler>()
            where THandler : class, IRequestHandler<TRequest, Either<Fail, TResponse>>
        {
            _services.AddScoped<IRequestHandler<TRequest, Either<Fail, TResponse>>, THandler>();
        }
    }
}