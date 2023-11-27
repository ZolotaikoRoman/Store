using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store.IdentityServer.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly IIdentityServerInteractionService _interaction;

        public LogoutModel(IIdentityServerInteractionService interaction)
        {
            _interaction = interaction;
        }

        [BindProperty]
        public string PostLogoutRedirectUri { get; set; }

        public async Task<IActionResult> OnGetAsync(string logoutId)
        {
            var info = await _interaction.GetLogoutContextAsync(logoutId);

            PostLogoutRedirectUri = info.PostLogoutRedirectUri;

            await HttpContext.SignOutAsync();

            return Page();
        }
    }
}
