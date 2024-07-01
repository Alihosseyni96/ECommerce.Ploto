using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.AuthenticationAbstraction.Configuration
{
    public static  class AuthenticationApplicationExtension
    {
        public static IApplicationBuilder AuthorizationAbstraction(this WebApplication webApplication , Action<AuthorizationOptions> action)
        {
            var options = new AuthorizationOptions(webApplication);
            action(options);
            return webApplication;
        }


        public class AuthorizationOptions
        {
            private readonly IApplicationBuilder _webApplication;

            public AuthorizationOptions(IApplicationBuilder webApplication)
            {
                _webApplication = webApplication;
            }


            public AuthorizationOptions UseAuthorizatio()
            {
                _webApplication.UseAuthorization();

                return this;
            }

            public AuthorizationOptions UseAuthentication()
            {
                _webApplication.UseAuthentication();

                return this;
            }
        }


    }
}
