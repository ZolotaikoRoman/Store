using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Common.Commands.Orders;

namespace Store.WebApi.Controllers
{
    [ApiController]
    [Route("/orders")]
    public class OrdersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _mediator.Send(new GetOrders()).ConfigureAwait(false);

            return result.ReduceTo<IActionResult>(BadRequest, Ok);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateOrder(CreateOrder order)
        {
            var result = await _mediator.Send(order).ConfigureAwait(false);

            return result.ReduceTo<IActionResult>(BadRequest, Ok);
        }
    }
}