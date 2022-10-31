using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using CAP_Backend_Source.Models;
using System.Data.Entity;

namespace CAP_Backend_Source.Services
{
    public class TokenService : OAuthAuthorizationServerProvider
    {
        AccountService userService = new AccountService();
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var acc = await userService.GetAsync(context.UserName, context.Password);
            if (acc == null)
            {
                context.SetError("Account Invalid", "Provided email and password is incorrect");
                return;
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Role, acc.Role));
            identity.AddClaim(new Claim(ClaimTypes.Sid, acc.Id.ToString()));
            identity.AddClaim(new Claim("Email", acc.Email));
            context.Validated(identity);
        }
    }
}
