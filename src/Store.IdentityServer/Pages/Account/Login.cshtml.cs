using IdentityServer4;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.IdentityServer.Models.Account;

namespace Store.IdentityServer.Pages.Account
{
    public class LoginModel(TestUserStore users) : PageModel
    {
        private readonly TestUserStore _users = users;

        [BindProperty]
        public UserCredentials Credentials { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_users.ValidateCredentials(Credentials.UserName, Credentials.Password))
            {
                var user = _users.FindByUsername(Credentials.UserName);

                var isuser = new IdentityServerUser(user.SubjectId)
                {
                    DisplayName = user.Username,
                };

                await HttpContext.SignInAsync(isuser);

                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
            }

            return LocalRedirect("/Index");
        }
    }
}
