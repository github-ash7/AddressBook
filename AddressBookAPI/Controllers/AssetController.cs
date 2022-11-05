using Contracts.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Controllers
{

    [ApiController]
    [Route("api/asset")]
    [Authorize]
    public class AssetController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserSignInService _signInService;

        public AssetController(IAccountService accountService,
            IUserSignInService signInService)
        {
            _accountService = accountService;
            _signInService = signInService;
        }

        /// <summary>
        /// File Upload API - stores a file in the database
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="file"></param>
        /// <returns></returns>

        [HttpPost("upload-file")]
        public IActionResult UploadFile([FromQuery] Guid userId, [FromForm] IFormFile file)
        {
            Guid loggedUserId = _signInService.GetLoggedUserId();

            //If the user is not a valid one,
            //return Not Found with the status code 404

            if (loggedUserId != userId)
            {
                return NotFound();
            }

            //Else, upload the given file and return Ok response

            return Ok(_accountService.UploadFile(file, userId));
        }

        /// <summary>
        /// File Download API - Gives a file as response stored in the database
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>

        [HttpGet("{assetId}")]
        public IActionResult DownloadFile([FromRoute] Guid assetId)
        {
            Guid loggedUserId = _signInService.GetLoggedUserId();

            //If the user is trying to download a file added by someone else, then 
            //return Not Found with the status code 404

            if (!_accountService.ValidateAssetId(assetId, loggedUserId))
            {
                return NotFound();
            }

            //Else, return the file stored in the database 

            Tuple<byte[], string> file = _accountService.DownloadFile(assetId);

            return new FileContentResult(file.Item1, file.Item2);
        }
    }
}

