using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityServer.Pages.Account
{
    public class LogoutModel(IIdentityServerInteractionService interaction) : PageModel
    {
        private readonly IIdentityServerInteractionService _interaction = interaction;

        [BindProperty(SupportsGet = true)]
        public string LogoutId { get; set; }

        [BindProperty]
        public LogoutRequest LogoutRequest { get; set; }

        public async Task<IActionResult> OnGet()
        {
            LogoutRequest = await _interaction.GetLogoutContextAsync(LogoutId).ConfigureAwait(false);

            await HttpContext.SignOutAsync().ConfigureAwait(false);

            return Page();
        }
    }
}
