using Entities.Dtos;
using System.Net;
using System.Security.Principal;

namespace Contracts.IServices
{
    public interface IAccountService
    {
        /// <summary>
        /// Adds an address book to the database
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>

        Guid AddAccount(UserCreateDto userAccount);

        /// <summary>
        /// Gets an address book details of a particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        UserResponseDto GetAddressBook(Guid userId);

        /// <summary>
        /// Counts the total number of user profiles in the database
        /// </summary>
        /// <returns></returns>

        int CountRecords ();

        /// <summary>
        /// Updates existing account details in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userAccount"></param>

        void UpdateAccountDetails(Guid id, UserUpdateDto userAccount);

        /// <summary>
        /// Deletes a user profile from the database
        /// </summary>
        /// <param name="userId"></param>

        void DeleteAccount(Guid id);

        /// <summary>
        /// Checks if an account exists in the database with the user name and email for the object of type UserCreateDto
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>

        Tuple<bool, string> AccountExists(UserCreateDto account);

        /// <summary>
        /// Checks if an account exists in the database with the user name and email for the object of type UserUpdateDto
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>

        Tuple<bool, string> AccountExists(Guid userId, UserUpdateDto account);

        /// <summary>
        ///Checks for the metadata given by the user in the database for the object of type UserCreateDto
        /// </summary>
        /// <returns></returns>

        bool MetaDataExists(UserCreateDto userAccount);

        /// <summary>
        /// Checks for the metadata given by the user in the database for the object of type UserUpdateDto
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        bool MetaDataExists(UserUpdateDto userAccount);

        /// <summary>
        /// Stores the byte[] form of a file in the database
        /// </summary>
        /// <param name="file"></param>
        /// <param name="userId"></param>

        UploadFileResponseDto UploadFile(IFormFile file, Guid userId);

        /// <summary>
        /// Retrieves and returns a stored file with its content type from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Tuple<byte[], string> DownloadFile(Guid id);

        /// <summary>
        /// Validates the requested file from user against their user id
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>

        bool ValidateAssetId(Guid assetId, Guid userId);
    }
}
