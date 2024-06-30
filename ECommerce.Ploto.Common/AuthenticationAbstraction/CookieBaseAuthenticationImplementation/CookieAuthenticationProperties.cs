using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.AuthenticationAbstraction.CookieBaseAuthenticationImpelimentation
{
    public class CookieAuthenticationProperties
    {
        /// <summary>
        /// Persist the cookie across browser sessions
        /// </summary>
        public bool IsPersistent { get; set; } = true;
        /// <summary>
        /// Set the expiration time of the cookie
        /// </summary>
        public DateTimeOffset? ExpiresUtc { get; set; } = DateTimeOffset.UtcNow.AddDays(30);
        /// <summary>
        /// Redirect URI after login
        /// </summary>
        public string? RedirectUri { get; set; } = "default-path";
        /// <summary>
        /// Set the issued time
        /// </summary>
        public DateTimeOffset? IssueDateUTC { get; set; }
        /// <summary>
        /// automatically renew the authentication cookie  under certain circumstances
        /// </summary>
        public bool? AllowRefresh { get; set; } = false;
        /// <summary>
        /// Login Path 
        /// </summary>
        public string LoginPath { get; set; } = "default-path";
        /// <summary>
        /// Logout Path 
        /// </summary>
        public string LogoutPath { get; set; }= "default-path";
    }
}
