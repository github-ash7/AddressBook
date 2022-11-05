using AddressBookAPI.Controllers;
using Contracts.IServices;
using Entities.Dtos;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AddressBookAPI.Tests.Controllers
{
    public class AuthControllerTests
    {
        private readonly IUserSignInService _signInService;
        private readonly ILogger<AuthController> _logger;
        private readonly AuthController _authController;

        public AuthControllerTests()
        {
            _signInService = A.Fake<IUserSignInService>();
            _logger = A.Fake<ILogger<AuthController>>();

            _authController = new AuthController(_signInService, _logger);
        }

        [Fact]
        public void Login_WhenCalledWithInvalidUsernameOrPassword_ReturnsUnauthorized()
        {
            //Arrange

            UserSignInDto signInModel = A.Fake<UserSignInDto>();
            TokenResponseDto token = null;
            A.CallTo(() => _signInService.Authenticate(signInModel)).Returns(token);

            //Act

            IActionResult result = _authController.Login(signInModel);

            //Assert

            result.Should().BeOfType<UnauthorizedResult>(); 
        }

        [Fact]
        public void Login_WhenCalledWithValidUsernameOrPassword_ReturnsOk()
        {
            //Arrange

            UserSignInDto signInModel = A.Fake<UserSignInDto>();
            TokenResponseDto token = A.Fake<TokenResponseDto>();
            A.CallTo(() => _signInService.Authenticate(signInModel)).Returns(token);

            //Act

            IActionResult result = _authController.Login(signInModel);
            OkObjectResult okResult = result as OkObjectResult;
            Object returnValue = okResult.Value;

            //Assert

            result.Should().BeOfType<OkObjectResult>();
            returnValue.Should().Be(token); 
        }
    }
}
