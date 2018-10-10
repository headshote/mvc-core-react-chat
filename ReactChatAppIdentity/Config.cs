using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace ReactChatAppIdentity
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
        {
            new ApiResource("reactchat", "React Chat App")
        };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
        {
            new Client
            {
                ClientId = "reactchat",
                ClientName = "React Chat App",

                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.Implicit,


                RedirectUris = { "http://localhost:5001/signin-oidc" },
                PostLogoutRedirectUris = { "http://localhost:5001/signout-callback-oidc" },

                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            }
        };
        }

        internal static List<TestUser> GetUsers()
        {
            return new List<TestUser> {
            new TestUser
            {
                SubjectId = "1",
                Username = "whatever",
                Claims = new []{ new Claim("name", "Ha Ha") },
                Password ="yeahno"
            }
        };
        }
    }
}
