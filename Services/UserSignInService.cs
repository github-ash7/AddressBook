using Contracts.IServices;
using Entities.Dtos;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Services.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class UserSignInService : IUserSignInService
    {
        private readonly RepositoryContext _context;
        private readonly IConfiguration _iconfiguration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserSignInService(RepositoryContext context, IConfiguration iconfiguration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _iconfiguration = iconfiguration;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Authenticates the user with the given username and password and returns token upon successful authentication
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public TokenResponseDto Authenticate(UserSignInDto user)
        {
            //Compares the username and password given by the user with the values stored in the DB,
            //and returns null if username/password is mismatched

            string password = _context.User.Where(a => a.UserName == user.UserName).Select(a => a.Password).SingleOrDefault();

            if (password == null || CommonMethods.DecryptPassword(password) != user.Password)
            {
                return null;
            }

            //Else, returns JWT token that allows users to access APIs

            string firstName = _context.User.Where(a => a.UserName == user.UserName).Select(a => a.FirstName).SingleOrDefault();

            string lastName = _context.User.Where(a => a.UserName == user.UserName).Select(a => a.LastName).SingleOrDefault();

            string userName = _context.User.Where(a => a.UserName == user.UserName).Select(a => a.UserName).SingleOrDefault();

            Guid currentUserId = _context.User.Where(a => a.UserName == user.UserName).Select(a => a.Id).SingleOrDefault();

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("user_id", currentUserId.ToString()),
                    new Claim("first_name", firstName),
                    new Claim("last_name", lastName),
                    new Claim("user_name", userName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(100),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new TokenResponseDto { Token = tokenHandler.WriteToken(token) };
        }

        public Guid GetLoggedUserId()
        {
            Guid loggedUserId = new Guid(_httpContextAccessor.HttpContext.User?.FindFirstValue("user_id"));
            return loggedUserId;
        }
    }
}
