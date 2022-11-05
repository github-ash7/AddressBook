using AddressBookAPI.Controllers;
using Contracts.IServices;
using Entities.Dtos;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AddressBookAPI.Tests.Controllers
{
    public class AssetControllerTests
    {
        private readonly IAccountService _accountService;
        private readonly IUserSignInService _signInService;
        private readonly ILogger<AssetController> _logger;
        private readonly AssetController _assetController;


        public AssetControllerTests()
        {
            _accountService = A.Fake<IAccountService>();
            _signInService = A.Fake<IUserSignInService>();
            _logger = A.Fake<ILogger<AssetController>>();

            _assetController = new AssetController(_accountService,
                                                   _signInService,
                                                   _logger);
        }

        [Fact]
        public void UploadFile_WhenCalledWithInvalidUserId_ReturnsNotFound()
        {
            //Arrange

            Guid id = Guid.NewGuid();
            Guid loggedUserId = Guid.NewGuid();
            IFormFile file = A.Fake<IFormFile>();
            A.CallTo(() => _signInService.GetLoggedUserId()).Returns(loggedUserId);

            //Act

            IActionResult result = _assetController.UploadFile(id, file);

            //Assert

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void UploadFile_WhenCalledWithValidUserId_ReturnsOkResponse()
        {
            //Arrange

            Guid id = Guid.NewGuid();
            IFormFile file = A.Fake<IFormFile>();
            UploadFileResponseDto uploadFileResponse = A.Fake<UploadFileResponseDto>();
            A.CallTo(() => _signInService.GetLoggedUserId()).Returns(id);
            A.CallTo(() => _accountService.UploadFile(file, id)).Returns(uploadFileResponse);

            //Act

            IActionResult result = _assetController.UploadFile(id, file);
            OkObjectResult okResult = result as OkObjectResult;
            Object returnValue = okResult.Value;

            //Assert

            result.Should().BeOfType<OkObjectResult>();
            returnValue.Should().Be(uploadFileResponse); 
        }

        [Fact]
        public void DownloadFile_WhenCalledWithInvalidAssetIdForAUserId_ReturnsNotFound()
        {
            //Arrange

            Guid assetId = Guid.NewGuid();
            Guid loggedUserId = Guid.NewGuid();
            A.CallTo(() => _signInService.GetLoggedUserId()).Returns(loggedUserId);
            A.CallTo(() => _accountService.ValidateAssetId(assetId, loggedUserId)).Returns(false);

            //Act

            IActionResult result = _assetController.DownloadFile(assetId);

            //Assert

            result.Should().BeOfType<NotFoundResult>();
        }

        #region Test

        //[Fact]
        //public void DownloadFile_WhenCalledWithValidAssetId_ReturnsFileContentResult()
        //{
        //    //Arrange

        //    Guid assetId = Guid.NewGuid();
        //    Guid loggedUserId = Guid.NewGuid();
        //    byte[] fileBytes = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
        //    A.CallTo(() => _signInService.GetLoggedUserId()).Returns(loggedUserId);
        //    A.CallTo(() => _accountService.ValidateAssetId(assetId, loggedUserId)).Returns(true);
        //    A.CallTo(() => _accountService.DownloadFile(assetId)).Returns(Tuple.Create(fileBytes, ""));

        //    //Act

        //    IActionResult result = _assetController.DownloadFile(assetId);

        //    //Assert

        //    result.Should().BeOfType<FileContentResult>();
        //}

        #endregion

    }
}
