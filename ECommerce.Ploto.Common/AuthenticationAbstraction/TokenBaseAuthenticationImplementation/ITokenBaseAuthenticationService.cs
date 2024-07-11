using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.AuthenticationAbstraction.TokenBaseAuthenticationImplementation
{
    /// <summary>
    /// This Abstraction Will Help You To Generate And Validate JWT Token - you Should Implement Logic of Login and logout
    /// </summary>
    public interface ITokenBaseAuthenticationService
    {
        string GenerateToken(params (string claimKey, string claimValue)[] addCleims);
        ClaimsPrincipal ValidateJwtToken(string token);
    }
}
