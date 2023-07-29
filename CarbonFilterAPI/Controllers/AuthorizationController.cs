using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using static OpenIddict.Abstractions.OpenIddictConstants;
using System.Security.Claims;

namespace CarbonFilterAPI.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IOpenIddictApplicationManager _applicationManager;

        public AuthorizationController(IOpenIddictApplicationManager applicationManager)
            => _applicationManager = applicationManager;       

        [HttpPost("~/connect/token")]
        public async Task<IActionResult> Exchange([FromServices] IServiceProvider serviceProvider)
        {
            var request = HttpContext.GetOpenIddictServerRequest();

            IServiceScope scope = serviceProvider.CreateScope();
            IOpenIddictApplicationManager _applicationManager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();
            var application = await _applicationManager.FindByClientIdAsync(request.ClientId) 
                ?? throw new InvalidOperationException("The application cannot be found.");

            // Create a new ClaimsIdentity containing the claims that will be used to create an id_token, a token or a code.
            var identity = new ClaimsIdentity(TokenValidationParameters.DefaultAuthenticationType, Claims.Name, Claims.Role);

            // Use the client_id as the subject identifier.
            identity.AddClaim(new Claim(Claims.Subject, await _applicationManager.GetClientIdAsync(application), Destinations.AccessToken, Destinations.IdentityToken));
            identity.AddClaim(new Claim(Claims.Name, await _applicationManager.GetDisplayNameAsync(application), Destinations.AccessToken, Destinations.IdentityToken));

            double tokenExpiryInterval = GetAccessTokenExpiryInterval();

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            principal.SetAudiences("console"); // only the AdminGroupApis client has permission to introspect this token
            principal.SetAccessTokenLifetime(TimeSpan.FromHours(tokenExpiryInterval));

            return SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        private double GetAccessTokenExpiryInterval()
        {
            double tokenExpiryInterval;
            StringValues tokenParam = HttpContext.Request.Form["tokenExpiryInHours"];
            if (tokenParam.Count > 0 && !string.IsNullOrWhiteSpace(tokenParam.First()))
            {
                tokenExpiryInterval = double.Parse(tokenParam.First());
            }
            else
            {
                // if tokenExpiryInHours parameter is not sent in request, setting the default token expiry time to 24 hours
                tokenExpiryInterval = 24;
            }

            return tokenExpiryInterval;
        }

    }

}
