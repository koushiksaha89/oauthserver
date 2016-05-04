using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin;
using System.Web.Http;
using AuthServer.Provider;

namespace AuthServer
{
    public partial class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions() { 
                AllowInsecureHttp=true,
                TokenEndpointPath= new PathString("/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                Provider = new AuthorizationServerProvider(),
                AuthorizeEndpointPath = new PathString("/Authorize"),
            };
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }
    }
}