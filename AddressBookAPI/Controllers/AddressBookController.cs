using Contracts.IServices;
using Entities.Dtos;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;


namespace AddressBookAPI.Controllers
{
    [ApiController]
    [Route("api/address-book")]
    [Authorize]
    public class AddressBookController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserSignInService _signInService;

        public AddressBookController(IAccountService accountService,
            IUserSignInService signInService)
        {
            _accountService = accountService;
            _signInService = signInService;
        }


        /// <summary>
        /// Get API - gets an address book of a user with their id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id:guid}")]
        public IActionResult GetAddressBookById([FromRoute] Guid id)
        {

            Guid loggedUserId = _signInService.GetLoggedUserId();

            //If the user is trying to access an address book added by someone else, then 
            //return Not Found with the status code 404

            if (loggedUserId != id)
            {
                return NotFound();
            }

            //Else, returns the address book with the status code 200

            UserResponseDto addressAtId = _accountService.GetAddressBook(id);

            return Ok(addressAtId);
        }

        /// <summary>
        /// Create API - creates an account in the database
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>

        [HttpPost("")]
        [AllowAnonymous]
        public IActionResult CreateAccount([FromBody] UserCreateDto account)
        {

            Tuple<bool, string> checkAccountExists = _accountService.AccountExists(account);

            //Returns 409 status code if the given username and email already existed in the database

            if (checkAccountExists.Item1)
                return Conflict(checkAccountExists.Item2);

            //Returns 404 status code if the meta data doesn't exists

            if (!_accountService.MetaDataExists(account))
                return NotFound("Invalid metadata");

            //Returns 201 status code after successful create operation

            Guid accountId =  _accountService.AddAccount(account);

            return StatusCode(StatusCodes.Status201Created, accountId);
        }

        /// <summary>
        /// Update API - updates the existing account details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="account"></param>
        /// <returns></returns>

        [HttpPut("{id:guid}")]
        public IActionResult UpdateAccount([FromRoute] Guid id, [FromBody] UserUpdateDto account)
        {

            Guid loggedUserId = _signInService.GetLoggedUserId();

            //If the user is trying to update an address book added by someone else, then this
            //returns Not Found with the status code 404

            if (loggedUserId != id)
            {
                return NotFound();
            }

            Tuple<bool, string> checkAccountExists = _accountService.AccountExists(id, account);

            //Returns 409 status code if the given username and email already existed in the database

            if (checkAccountExists.Item1)
                return Conflict(checkAccountExists.Item2);

            //Returns 404 status code if the meta data doesn't exists

            if (!_accountService.MetaDataExists(account))
                return NotFound("Invalid metadata");

            _accountService.UpdateAccountDetails(id, account);

            return Ok();
        }

        /// <summary>
        /// Delete API - deletes an existing user profile with their id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteRecord([FromRoute] Guid id)
        {
            Guid loggedUserId = _signInService.GetLoggedUserId();

            //If the user is trying to delete an address book added by someone else, then 
            //return Not Found with the status code 404

            if (loggedUserId != id)
            {
                return NotFound();
            }

            _accountService.DeleteAccount(id);

            return Ok();
        }
    }
}
