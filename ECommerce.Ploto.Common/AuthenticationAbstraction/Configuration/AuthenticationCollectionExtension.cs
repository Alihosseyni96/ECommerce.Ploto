using ECommerce.Ploto.Common.AuthenticationAbstraction.CookieBaseAuthenticationImpelimentation;
using ECommerce.Ploto.Common.AuthenticationAbstraction.TokenBaseAuthenticationImplementation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECommerce.Ploto.Common.CacheAbstraction.Configurations.CacheServiceCollectionExtensions;

namespace ECommerce.Ploto.Common.AuthenticationAbstraction.Configuration
{
    public static class AuthenticationCollectionExtension
    {
        public static IServiceCollection AddAuthenticationAbstraction(this IServiceCollection services, Action<AuthenticationConfig> action)
        {
            var config = new AuthenticationConfig(services);
            action(config);
            return services;

        }

        public class AuthenticationConfig
        {
            private readonly IServiceCollection _service;

            public AuthenticationConfig(IServiceCollection service)
            {
                _service = service;
            }

            public AuthenticationConfig UseCookieBaseAuthentication(Action<CookieAuthenticationProperties> action)
            {
                var coockiOptions = new CookieAuthenticationProperties();     // action will fill coockiOption
                action(coockiOptions);
                _service.AddHttpContextAccessor();
                _service.AddScoped<ICookieBaseAuthenticationService, CookieBaseAuthenticationService>();
                _service.AddSingleton(coockiOptions);
                _service.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                    {
                        options.LoginPath = coockiOptions.LoginPath;
                        options.LogoutPath = coockiOptions.LogoutPath;
                    });

                return this;
            }

            public AuthenticationConfig UseTokenBaseAuthentication(Action<TokenauthenticationOptions> action) 
            {
                var tokenOptions = new TokenauthenticationOptions();
                action(tokenOptions);

                _service.AddSingleton(tokenOptions);
                _service.AddScoped<ITokenBaseAuthenticationService, TokenBaseAuthenticationService>();

                if (tokenOptions.AddingAuthenticationServicesToDI)
                {
                    _service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                        {
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = tokenOptions.Issuer,
                                ValidAudience = tokenOptions.Audience,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.JwtKey))
                            };
                        });
                }

                return this;

            }
        }
    }
}
