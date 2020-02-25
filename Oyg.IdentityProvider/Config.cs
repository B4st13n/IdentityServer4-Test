// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Oyg.Idp
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[] 
            { };
        
        public static IEnumerable<Client> Clients =>
            new Client[] 
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
                    //AllowedCorsOrigins = new List<string>()
                    //{
                    //    "https://www.getpostman.com"
                    //},
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("NotASecret".Sha256())
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