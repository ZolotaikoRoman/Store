using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer.Config
{
    public static class IdentityConfig
    {
        public static List<TestUser> Users => new()
        {
            new TestUser
            {
                SubjectId = "4815162342",
                Username = "admin",
                Password = "password",
                Claims = new[]
                {
                    new Claim(JwtClaimTypes.FamilyName, "superadmin"),
                    new Claim(JwtClaimTypes.GivenName, "megaadmin"),
                },
            },
        };

        public static List<IdentityResource> Resources => new()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

        public static List<Client> Clients => new()
        {
            new Client
            {
                ClientName = "Todos MVC",
                ClientId = "todos.mvc",
                ClientSecrets = new[] { new Secret("todos.mvc".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = new string[]
                {
                    "https://localhost:5001/signin-oidc",
                },
                PostLogoutRedirectUris = new string[]
                {
                    "https://localhost:5001/signout-callback-oidc",
                },
                AllowedScopes = new[]
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                },
            }
        };
    }
}
