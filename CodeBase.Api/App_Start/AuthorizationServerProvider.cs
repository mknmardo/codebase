using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CodeBase.Api.App_Start
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            string role = null;
            bool? IsLockedOut = null;

            
            //Create AuthService to validate credentials and get role


            if (role == null)
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }

            if ((bool)IsLockedOut)
            {
                context.SetError("invalid_grant", "Account disabled");
                return;
            }



            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Role, role));

            context.Validated(identity);
        }
    }
}