using AddressBookAPI.Controllers;
using Contracts.IServices;
using Entities.Dtos;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AddressBookAPI.Tests.Controllers
{
    public class AddressBookControllerTests
    {
        private readonly IAccountService _accountService;
        private readonly IUserSignInService _signInService;
        private readonly ILogger<AddressBookController> _logger;
        private readonly AddressBookController _addressBookController;

        public AddressBookControllerTests()
        {
            _accountService = A.Fake<IAccountService>();
            _signInService = A.Fake<IUserSignInService>();
            _logger = A.Fake<ILogger<AddressBookController>>();

            _addressBookController = new AddressBookController(_accountService,
                                                               _signInService,
                                                               _logger);
        }

        [Fact]
        public void GetAddressBookById_WhenCalledWithInvalidUserId_ReturnNotFound()
        {
            //Arrange

            Guid id = Guid.NewGuid();
            Guid loggedUserId = Guid.NewGuid();
            A.CallTo(() => _signInService.GetLoggedUserId()).Returns(loggedUserId);

            //Act

            IActionResult result = _addressBookController.GetAddressBookById(id);

            //Assert

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetAddressBookById_WhenCalledWithValidUserId_ReturnOk()
        {
            //Arrange

            Guid id = Guid.NewGuid();
            UserResponseDto addressBook = A.Fake<UserResponseDto>();
            A.CallTo(() => _signInService.GetLoggedUserId()).Returns(id);
            A.CallTo(() => _accountService.GetAddressBook(id)).Returns(addressBook);

            //Act

            IActionResult result = _addressBookController.GetAddressBookById(id);
            OkObjectResult okResult = result as OkObjectResult;
            Object returnValue = okResult.Value;

            //Assert

            result.Should().BeOfType<OkObjectResult>();
            returnValue.Should().Be(addressBook); 
        }

        [Fact]
        public void CountAccounts_WhenCalled_ReturnAValueOfTypeInteger()
        {
            //Arrange

            A.CallTo(() => _accountService.CountRecords()).Returns(10);

            //Act

            IActionResult result = _addressBookController.CountAccounts();
            OkObjectResult okResult = result as OkObjectResult;
            Object returnValue = okResult.Value;

            //Asset

            result.Should().BeOfType<OkObjectResult>();
            returnValue.Should().BeOfType<System.Int32>();
        }

        [Fact]
        public void CreateAccount_WhenCalledWithExistingUserNameOrEmail_ReturnsConflict()
        {
            //Arrange

            UserCreateDto createAddressBook = A.Fake<UserCreateDto>();
            A.CallTo(() => _accountService.AccountExists(createAddressBook)).Returns(Tuple.Create(true, "Username/Password exists"));

            //Act

            IActionResult result = _addressBookController.CreateAccount(createAddressBook);

            //Assert

            result.Should().BeOfType<ConflictObjectResult>();
        }

        [Fact]
        public void CreateAccount_WhenCalledWithInvalidMetadata_ReturnsNotFound()
        {
            //Arrange

            UserCreateDto createAddressBook = A.Fake<UserCreateDto>();
            A.CallTo(() => _accountService.AccountExists(createAddressBook)).Returns(Tuple.Create(false, ""));
            A.CallTo(() => _accountService.MetaDataExists(createAddressBook)).Returns(false);

            //Act

            IActionResult result = _addressBookController.CreateAccount(createAddressBook);

            //Assert

            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public void CreateAccount_WhenCalledWithValidAddressBookDetails_Returns201StatusCode()
        {
            //Arrange

            UserCreateDto createAddressBook = A.Fake<UserCreateDto>();
            Guid id = Guid.NewGuid();
            A.CallTo(() => _accountService.AccountExists(createAddressBook)).Returns(Tuple.Create(false, ""));
            A.CallTo(() => _accountService.MetaDataExists(createAddressBook)).Returns(true);
            A.CallTo(() => _accountService.AddAccount(createAddressBook)).Returns(id);

            //Act

            IActionResult result = _addressBookController.CreateAccount(createAddressBook);
            ObjectResult createdResult = result as ObjectResult;
            Object returnValue = createdResult.Value;

            //Assert

            result.Should().BeOfType<ObjectResult>();
            returnValue.Should().BeOfType<Guid>();
        }

        [Fact]
        public void UpdateAccount_WhenCalledWithInvalidUserId_ReturnNotFound()
        {
            //Arrange

            Guid id = Guid.NewGuid();
            Guid loggedUserId = Guid.NewGuid();
            UserUpdateDto updateAddressBook = A.Fake<UserUpdateDto>();
            A.CallTo(() => _signInService.GetLoggedUserId()).Returns(loggedUserId);

            //Act

            IActionResult result = _addressBookController.UpdateAccount(id, updateAddressBook);

            //Assert

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void UpdateAccount_WhenCalledWithExistingUserNameOrEmail_ReturnsConflict()
        {
            //Arrange

            Guid id = Guid.NewGuid();
            UserUpdateDto updateAddressBook = A.Fake<UserUpdateDto>();
            A.CallTo(() => _signInService.GetLoggedUserId()).Returns(id);
            A.CallTo(() => _accountService.AccountExists(id, updateAddressBook)).Returns(Tuple.Create(true, "Username/Password exists"));

            //Act

            IActionResult result = _addressBookController.UpdateAccount(id, updateAddressBook);

            //Assert

            result.Should().BeOfType<ConflictObjectResult>();
        }

        [Fact]
        public void UpdateAccount_WhenCalledWithInvalidMetadata_ReturnsNotFound()
        {
            //Arrange

            UserUpdateDto updateAddressBook = A.Fake<UserUpdateDto>();
            Guid id = Guid.NewGuid();
            A.CallTo(() => _signInService.GetLoggedUserId()).Returns(id);
            A.CallTo(() => _accountService.AccountExists(id, updateAddressBook)).Returns(Tuple.Create(false, ""));
            A.CallTo(() => _accountService.MetaDataExists(updateAddressBook)).Returns(false);

            //Act

            IActionResult result = _addressBookController.UpdateAccount(id, updateAddressBook);

            //Assert

            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public void UpdateAccount_WhenCalledWithValidUserId_ReturnOk()
        {
            //Arrange

            UserUpdateDto updateAddressBook = A.Fake<UserUpdateDto>();
            Guid id = Guid.NewGuid();
            A.CallTo(() => _signInService.GetLoggedUserId()).Returns(id);
            A.CallTo(() => _accountService.AccountExists(id, updateAddressBook)).Returns(Tuple.Create(false, ""));
            A.CallTo(() => _accountService.MetaDataExists(updateAddressBook)).Returns(true);
            A.CallTo(() => _accountService.UpdateAccountDetails(id, updateAddressBook));

            //Act

            IActionResult result = _addressBookController.UpdateAccount(id, updateAddressBook);

            //Assert

            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public void DeleteAccount_WhenCalledWithInvalidUserId_ReturnsNotFound()
        {
            //Arrange

            Guid id = Guid.NewGuid();
            Guid loggedUserId = Guid.NewGuid();
            A.CallTo(() => _signInService.GetLoggedUserId()).Returns(loggedUserId);

            //Act

            IActionResult result = _addressBookController.DeleteRecord(id);

            //Assert

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void DeleteAccount_WhenCalledWithValidUserId_ReturnsOk()
        {
            //Arrange

            Guid id = Guid.NewGuid();
            A.CallTo(() => _signInService.GetLoggedUserId()).Returns(id);
            A.CallTo(() => _accountService.DeleteAccount(id));

            //Act

            IActionResult result = _addressBookController.DeleteRecord(id);

            //Assert

            result.Should().BeOfType<OkResult>();
        }
    }
}
