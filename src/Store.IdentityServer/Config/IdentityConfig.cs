using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace Store.IdentityServer.Config
{
    public static class IdentityConfig
    {
        public static List<TestUser> Users => new()
        {
            new TestUser
            {
                SubjectId = Guid.NewGuid().ToString(),
                Username = "admin",
                Password = "password",
                Claims = new[]
                {
                    new Claim(JwtClaimTypes.Name, "admin"),
                    new Claim(JwtClaimTypes.FamilyName, "superadmin")
                },
            },
        };

        public static List<IdentityResource> IdentityResources => new()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

        public static List<Client> Clients => new()
        {
            new Client()
            {
                ClientName = "Store API",
                ClientId = "store.api",
                AllowedGrantTypes = GrantTypes.Code,
                ClientSecrets = new[] { new Secret("secret".Sha256()) },
                AllowedScopes = new[]
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                },
                RedirectUris = new[]
                {
                    "https://localhost:5002/signin-oidc"
                },
            },
            new Client()
            {
                ClientName = "TEST MVC",
                ClientId = "test.mvc",
                AllowedGrantTypes = GrantTypes.Code,
                ClientSecrets = new[] { new Secret("testmvc".Sha256()) },
                AllowedScopes = new[]
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                },
                RedirectUris = new[]
                {
                    "https://localhost:5003/signin-oidc"
                },
                PostLogoutRedirectUris = new[]
                {
                    "https://localhost:5003/signout-callback-oidc"
                }
            },
        };
    }
}
