using GoldenLotteryAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static GoldenLotteryAPI.Core.Enums;

namespace GoldenLotteryAPI.Core
{
    public static class TokenService
    {
        private static readonly string Secret = "E922FA892E9FF138330138750AD79FB9FE691DB7581D089461F76FB2395D22A8";

        public static string GenerateTokenCustomer(Customer customer)
        {
            var _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
            var signinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                    issuer: "GoldenLotteryFrontend",
                    audience: "GoldenLoterryAPI",
                    claims: new List<Claim>
                    {
                        new(ClaimTypes.Name, customer.Name),
                        new(ClaimTypes.Email, customer.Email),
                        new("CustomerId", customer.CustomerId.ToString()),
                        new(ClaimTypes.Role, EUserRoles.Customer.ToString())
                    },
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: signinCredentials);

            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }

        public static string GenerateTokenAdministrator(Administrator administrator)
        {
            var _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
            var signinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                    issuer: "GoldenLotteryFrontend",
                    audience: "GoldenLoterryAPI",
                    claims: new List<Claim>
                    {
                        new(ClaimTypes.Name, administrator.Name),
                        new(ClaimTypes.Email, administrator.Email),
                        new(ClaimTypes.Role, EUserRoles.Administrator.ToString())
                    },
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: signinCredentials);

            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }
    }
}
