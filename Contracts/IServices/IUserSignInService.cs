using Entities.Dtos;

namespace Contracts.IServices
{
    public interface IUserSignInService
    {
        /// <summary>
        /// Authenticates the user with the given username and password and returns token upon successful authentication
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        TokenResponseDto Authenticate(UserSignInDto user);

        /// <summary>
        /// Returns the logged-in user id from claims
        /// </summary>
        /// <returns></returns>

        Guid GetLoggedUserId();
    }
}
