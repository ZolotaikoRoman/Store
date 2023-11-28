using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;

namespace Todos.MVC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                options.Authority = "https://localhost:5000";
                options.ClientId = "todos.mvc";
                options.ClientSecret = "todos.mvc";
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.ResponseType = "code";
                options.SaveTokens = true;

                options.Scope.Add("roles");

                options.ClaimActions.MapJsonKey("role", "role");
            });
        }
    }
}