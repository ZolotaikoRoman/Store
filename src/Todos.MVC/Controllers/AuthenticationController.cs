using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Todos.MVC.Controllers
{
    [Authorize]
    [Route("/auth")]
    public class AuthenticationController : ControllerBase
    {
        [Route("login")]
        public IActionResult Login()
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = "/Items",
            });
        }

        [Route("logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).ConfigureAwait(false);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme).ConfigureAwait(false);
        }
    }
}
