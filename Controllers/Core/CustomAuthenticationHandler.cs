using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.Ocsp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using static CustomAuthenticationHandler;

public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthenticationOptions>
{
    private static readonly string Secret = "E922FA892E9FF138330138750AD79FB9FE691DB7581D089461F76FB2395D22A8";

    public CustomAuthenticationHandler(
    IOptionsMonitor<CustomAuthenticationOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder,
    ISystemClock clock)
    : base(options, logger, encoder, clock)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(token))
            return Task.FromResult(AuthenticateResult.NoResult());

        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)),
                ValidateIssuer = true,
                ValidIssuer = "GoldenLotteryFrontend",
                ValidateAudience = true,
                ValidAudience = "GoldenLoterryAPI"
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

            var claimsIdentity = new ClaimsIdentity(principal.Claims, Scheme.Name);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var ticket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
        catch (Exception)
        {
            return Task.FromResult(AuthenticateResult.Fail("Falha na autenticação do token."));
        }
    }
}

public class CustomAuthenticationOptions : AuthenticationSchemeOptions
{
}