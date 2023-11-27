using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Store.WebApi.Controllers
{
    [ApiController]
    [Route("authorize")]
    [Authorize]
    public class DummyController : ControllerBase
    {
        private readonly ILogger<DummyController> _logger;

        public DummyController(ILogger<DummyController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> GetInfo()
        {
            var claims = HttpContext.User;

            foreach (var c in claims.Claims)
            {
                _logger.LogInformation($"Claim info : {c.Value}, {c.ValueType}, {c.OriginalIssuer}, {c.Issuer}, {c.Subject}");
            }

            var token = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            _logger.LogInformation($"Token :{token}");

            return Ok();
        }
    }
}