using IdentityServer.Models;
using IdentityServer4;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityServer.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly TestUserStore _userStore;

        public LoginModel(TestUserStore userStore)
        {
            _userStore = userStore;
        }

        [BindProperty]
        public LoginViewModel Creds { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_userStore.ValidateCredentials(Creds.UserName, Creds.Password))
            {
                var user = _userStore.FindByUsername(Creds.UserName);

                var isuser = new IdentityServerUser(user.SubjectId)
                {
                    DisplayName = user.Username
                };

                await HttpContext.SignInAsync(isuser).ConfigureAwait(false);

                if (!string.IsNullOrWhiteSpace(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
            }

            return Redirect("/");
        }
    }
}