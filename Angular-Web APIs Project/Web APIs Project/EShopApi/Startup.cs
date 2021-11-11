using EShopApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

[assembly: OwinStartup(typeof(EShopApi.Startup))]
namespace EShopApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true,
                Provider = new TokenCreate()
            });

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/register"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true,
                Provider = new RegisterTokenCreate()
            });

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            EnableCorsAttribute corsAttribute = new EnableCorsAttribute("*", "*", "*");

            HttpConfiguration config = new HttpConfiguration();

            config.EnableCors(corsAttribute);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
        }
    }

    internal class RegisterTokenCreate : OAuthAuthorizationServerProvider
    {
        ApplicationDbContext Dbcontext = new ApplicationDbContext();
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add(" Access - Control - Allow - Origin ", new[] { "*" });

            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(Dbcontext);
            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(store);

            ApplicationUser user = new ApplicationUser
            {
                Email = context.UserName,
                UserName = context.UserName
            };

            var result = await manager.CreateAsync(user, context.Password);

            if (!result.Succeeded)
            {
                context.SetError("grant_error", "Invalid registeration , check email and password again");
            }
            else
            {
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                if (manager.IsInRole(user.Id, "Admin"))
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                }
                context.Validated(claimsIdentity);
            }
        }
    }

    internal class TokenCreate : OAuthAuthorizationServerProvider
    {
        ApplicationDbContext Dbcontext = new ApplicationDbContext();
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add(" Access - Control - Allow - Origin ", new[] { "*" });

            UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(Dbcontext);
            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(store);
            ApplicationUser user =  await manager.FindAsync(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("grant_error", "Invalid registeration , check email and password again");
            }
            else
            {
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                if (manager.IsInRole(user.Id, "Admin"))
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                }
                context.Validated(claimsIdentity);
            }
        }
    }
}
