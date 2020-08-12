using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace learn_net_core
{
    public static class AuthenticationConfig
    {
        public static string generateJsonWebToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]{
                new Claim(ClaimTypes.Role,"Admin")
            };
            var token = new JwtSecurityToken(
                "http://localhost:5000", "http://localhost:5000", claims, DateTime.Now,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static void ConfigureJwtAuthentication(this IServiceCollection services)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenValidationParams = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidIssuer = "http://localhost:5000",
                ValidateLifetime = true,
                ValidAudience = "http://localhost:5000",
                RequireSignedTokens = true,
                IssuerSigningKey = credentials.Key,
                ClockSkew = TimeSpan.FromMinutes(30),
            };
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParams;
#if PROD || UAT
                    options.IncludeErrorDetails=false;
#elif DEBUG
                options.RequireHttpsMetadata = false;
#endif
            });
        }
    }
}