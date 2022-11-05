using Contracts.IServices;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserSignInService _signInService;

        public AuthController(IUserSignInService signInService)
        {
            _signInService = signInService;
        }

        /// <summary>
        /// Login API
        /// </summary>
        /// <param name="signInModel"></param>
        /// <returns></returns>

        [HttpPost("sign-in")]
        public IActionResult Login([FromBody] UserSignInDto signInModel)
        {
            TokenResponseDto token = _signInService.Authenticate(signInModel);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
