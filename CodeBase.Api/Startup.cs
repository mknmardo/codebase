using CodeBase.Api.App_Start;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

namespace CodeBase.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/v1/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthAuthorizationServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            app.UseWebApi(WebApiConfig.Register());
        }
    }
    }
}