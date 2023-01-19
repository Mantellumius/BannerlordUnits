// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace BannerlordUnits.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new[]
            {
                new ApiScope("TroopsApi"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new()
                {
                    ClientId = "BannerlordUnitsSite",
                    ClientName = "BannerlordUnitsSiteUser",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RedirectUris = {"https://localhost:7297/authentication/login-callback", "https://localhost:5294/authentication/login-callback"},
                    // secret for authentication
                    // ClientSecrets =
                    // {
                    //     new Secret("PzT2mPkoC8YAjg5q0smyyW8GuqC93LBY".Sha256())
                    // },

                    // scopes that client has access to
                    AllowedScopes =
                    {
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                        "TroopsApi",
                    }
                }
            };
    }
}