using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Asp.Net.Core.JWT.Helpers
{

    /// <summary>
    ///   Store active user list and get users by token
    ///   this is template to user store system. 
    ///   
    /// </summary>
    public class UserStore
    {

        public const double Expared = 1.0;

        /// <summary>
        ///    Get user by token and check if tokent is exparied
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static DateTime GetDateOfBirth(string token)
        {
            var jwtToken = new JwtSecurityToken(token);
            var str_dateOfBird = jwtToken.Claims.Where(c => c.Type == ClaimTypes.DateOfBirth)
                 .Select(c => c.Value).SingleOrDefault();
            long long_time;
            long.TryParse(str_dateOfBird, out long_time);
            DateTime dateOfBird = new DateTime(long_time);

            return dateOfBird;
        }

    }
}
