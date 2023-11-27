using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Todos.MVC.Controllers
{
    [Authorize]
    [Route("/logout")]
    public class LogoutController : ControllerBase
    {
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).ConfigureAwait(false);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme).ConfigureAwait(false);
        }
    }
}
