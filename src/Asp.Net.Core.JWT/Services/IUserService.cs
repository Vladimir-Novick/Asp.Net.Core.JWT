using Asp.Net.Core.JWT.Entities;

namespace Asp.Net.Core.JWT.Services
{
    public interface IUserService
    {
        /// <summary>
        ///    User Authentication
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User Authenticate(string username, string password);

    }
}
