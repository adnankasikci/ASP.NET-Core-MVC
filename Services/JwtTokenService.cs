using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using AppSpace.Models;

namespace AppSpace.Services
{
    public class JwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(string name, string surname, string email)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var secretKey = jwtSettings["SecretKey"] ?? "defaultSecretKey";
            var issuer = jwtSettings["Issuer"] ?? "defaultIssuer";
            var audience = jwtSettings["Audience"] ?? "defaultAudience";

            var claims = new List<Claim>
                {
                    new Claim("Name", name),
                    new Claim("Surname",surname),
                    new Claim("email", email),
                };


            var expiryDuration = int.TryParse(jwtSettings["ExpiryDurationInMinutes"], out var duration) ? duration : 30;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddMinutes(expiryDuration),
                signingCredentials: credentials,
                claims: claims
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenDescriptor);
            return token;
        }
    }
}