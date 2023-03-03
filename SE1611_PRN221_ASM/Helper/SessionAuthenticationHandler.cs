using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using SE1611_PRN221_ASM.Models;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace SE1611_PRN221_ASM.Helper
{
    public class SessionAuthenticationHandler : AuthenticationHandler<SessionAuthenticationOptions>
    {
        public SessionAuthenticationHandler(IOptionsMonitor<SessionAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Check the session for the necessary data
            var userSession = Context.Session.GetObject<UserSession>("UserSession");

            if (userSession == null)
            {
                var properties = new AuthenticationProperties
                {
                    RedirectUri = "/account/signin",
                };
                return Task.FromResult(AuthenticateResult.Fail(new Exception("User is not authenticated"), properties));
            }

            // Create a ClaimsIdentity with the necessary claims
            var claims = new[] { new Claim("email", userSession.Email)};
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            Logger.LogWarning("User Identify" + userSession.Email);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.Redirect("/account/signin");
            //if (properties != null && !string.IsNullOrEmpty(properties.RedirectUri))
            //{
            //    Response.Redirect(properties.RedirectUri);
            //}
            //else
            //{
            //    Response.Redirect("/account/signin");
            //}

            return Task.CompletedTask;
        }
    }
}
