using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace <%= projectName %>.Web.Infrastructure.OAuth {
    /// <summary>
    /// Custom authorization filter
    /// </summary>
    public class AuthorizationBearerFilter : Attribute, IAuthenticationFilter {

        public bool AllowMultiple { get { return false; } }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken) {

            var request = context.Request;
            var authorization = request.Headers.Authorization;
            if (authorization == null) {
                return Task.FromResult<object>(null);
            }
            if (authorization.Scheme != "Bearer") return Task.FromResult<object>(null);
            cancellationToken.ThrowIfCancellationRequested();

            var ticket = Startup.OAuthAuthorizationServerOptions.AccessTokenFormat.Unprotect(authorization.Parameter);
            if (ticket == null) return Task.CompletedTask;

            var identity = new ClaimsIdentity(ticket.Identity.Claims, "Bearer");
            var principal = new ClaimsPrincipal(identity);
            context.Principal = principal;
            return Task.FromResult<object>(null);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken) {
            var challenge = new AuthenticationHeaderValue("Bearer");
            context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
            return Task.FromResult(0);
        }
    }
}
