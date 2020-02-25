using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;

namespace Oyg.IdentityServer
{
    public static class Config
    {
        private static IConfiguration _configuration;

        internal static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // test users
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "d860efca-22d9-47fd-8249-791ba61b07c7",
                    Username = "Bastien",
                    Password = "P@ssw0rd",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Bastien"),
                        new Claim("family_name", "Vandamme"),
                        new Claim("role", "student")
                    }
                },
                new TestUser
                {
                    SubjectId = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                    Username = "Ching",
                    Password = "P@ssw0rd",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Ching Yng"),
                        new Claim("family_name", "Choi"),
                        new Claim("role", "teacher")
                    }
                }
            };
        }

        //identity-related resources(scopes)
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            var roleProfile = new IdentityResource(
                name: "roles",
                displayName: "Your role(s)",
                claimTypes: new[] { "role" });

            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                roleProfile
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("oygapi", "Organic Yoga Girl Api",
                    new List<string>() { "role" })
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    //AccessTokenType = AccessTokenType.Jwt,
                    ClientName = "Postman", //_configuration.GetSection("PostmanClient").GetValue<string>("ClientName"),
                    ClientId = "f26ee5d6-de33-4375-bc79-54550efa43d9.local.app", //_configuration.GetSection("PostmanClient").GetValue<string>("ClientId"),
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowOfflineAccess = true,
                    IdentityTokenLifetime = 120,
                    AccessTokenLifetime = 120,
                    RedirectUris = new List<string>()
                    {
                        "https://www.getpostman.com/oauth2/callback"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://www.getpostman.com"
                    },
                    AllowedCorsOrigins = new List<string>()
                    {
                        "https://www.getpostman.com"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "oygapi",
                        "roles"
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("NotASecret")
                    },
                    //RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    //RequireConsent = false,
                    EnableLocalLogin = true,
                    Enabled = true,
                }
             };

        }
    }
}
