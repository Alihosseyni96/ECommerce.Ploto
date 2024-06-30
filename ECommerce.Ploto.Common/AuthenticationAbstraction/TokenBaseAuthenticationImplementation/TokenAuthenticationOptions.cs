using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.AuthenticationAbstraction.TokenBaseAuthenticationImplementation
{
    public class TokenauthenticationOptions
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string JwtKey { get; set; }
        public DateTime Expires { get; set; }
        /// <summary>
        /// if you do not want to create Custome authorization middleware, you should add service to DI container and introduce how you aithentication service works to be able open you token and claims
        /// if you want to create custome Middleware to authorize request , no need to add service to container and application dont need to know how your authentication service works
        /// --- When You Add type Of you Authentication Service to DI container , it will find out how is it and it can open token of requets and [Authorize] attribute can works fine
        /// </summary>
        public bool AddingAuthenticationServicesToDI { get; set; } = true;
    }
}
