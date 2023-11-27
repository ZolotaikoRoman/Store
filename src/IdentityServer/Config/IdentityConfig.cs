using IdentityModel;
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
    }
}
