using AutoMapper;
using Contracts.IServices;
using Entities.Dtos;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services.Helpers;
using System;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public AccountService(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds an address book to the database
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>

        public Guid AddAccount(UserCreateDto userAccount)
        {
            //Automaps the data from the object of type UserCreateDto to User

            User user = _mapper.Map<User>(userAccount);

            //Encrypts the given password 

            user.Password = CommonMethods.EncryptPassword(userAccount.Password);

            //Iterates through all the emails and assigns them with their respective user id 
            //and refterm id

            foreach (Email email in user.Emails)
            {
                email.UserId = user.Id;

                email.RefTermId = ServiceHelperMethods.GetRefTermId(userAccount.Emails
                    .Where(a => a.EmailAddress == email.EmailAddress)
                    .Select(a => a.Type).SingleOrDefault().ToString(), _context);
            }

            //Iterates through all the addresses and assigns them with their respective user id 
            //and refterm id

            foreach (Address address in user.Addresses)
            {
                address.UserId = user.Id;

                address.RefTermId = ServiceHelperMethods.GetRefTermId(userAccount.Addresses
                    .Where(a => a.Line1 == address.Line1 && a.Line2 == address.Line2)
                    .Select(a => a.Type).SingleOrDefault().ToString(), _context);
            }

            //Iterates through all the phones and assigns them with their respective user id 
            //and refterm id

            foreach (Phone phone in user.Phones)
            {
                phone.UserId = user.Id;

                phone.RefTermId = ServiceHelperMethods.GetRefTermId(userAccount.Phones
                    .Where(a => a.PhoneNumber == phone.PhoneNumber)
                    .Select(a => a.Type).SingleOrDefault().ToString(), _context);
            }

            //Adds the record the database
            _context.User.Add(user);

            _context.SaveChanges();

            return user.Id;
        }


        /// <summary>
        /// Gets an address book details of a particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        public UserResponseDto GetAddressBook(Guid userId)
        {
            //Gets the address book for the given id from the database

            User userUser = _context.User.Where(a => a.Id == userId).FirstOrDefault();
            List<Email> userEmails = _context.Email.Where(a => a.UserId == userId).ToList();
            List<Address> userAddresses = _context.Address.Where(a => a.UserId == userId).ToList();
            List<Phone> userPhones = _context.Phone.Where(a => a.UserId == userId).ToList();

            //Automaps the data from the object of type User to UserResponseDto

            UserResponseDto addressBook = _mapper.Map<UserResponseDto>(userUser);

            //Decrypts the password 

            addressBook.Password = CommonMethods.DecryptPassword(addressBook.Password);

            //Iterates through all the emails and assigns them with a type for their 
            //refterm id

            foreach (EmailResponseDto email in addressBook.Emails)
            {
                email.Type = ServiceHelperMethods.GetRefTermKey(userEmails
                             .Where(a => a.EmailAddress == email.EmailAddress)
                             .Select(a => a.RefTermId).SingleOrDefault(), _context);
            }

            //Iterates through all the addresses and assigns them with a type for their 
            //refterm id

            foreach (AddressResponseDto address in addressBook.Addresses)
            {
                address.Type = ServiceHelperMethods.GetRefTermKey(userAddresses
                               .Where(a => a.Line1 == address.Line1 && a.Line2 == address.Line2)
                               .Select(a => a.RefTermId).SingleOrDefault(), _context);
            }

            //Iterates through all the phones and assigns them with a type for their 
            //refterm id

            foreach (PhoneResponseDto phone in addressBook.Phones)
            {
                phone.Type = ServiceHelperMethods.GetRefTermKey(userPhones
                            .Where(a => a.PhoneNumber == phone.PhoneNumber)
                            .Select(a => a.RefTermId).SingleOrDefault(), _context);
            }

            return addressBook;
        }


        /// <summary>
        /// Counts the total number of user profiles in the database
        /// </summary>
        /// <returns></returns>

        public int CountRecords()
        {
            return _context.User.Count();
        }

        /// <summary>
        /// Updates existing account details in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userAccount"></param>

        public void UpdateAccountDetails(Guid id, UserUpdateDto userAccount)
        {
            //Automaps the data from the object of type UserUpdateDto to User

            User user = _mapper.Map<User>(userAccount);

            user.Id = id;

            user.Password = CommonMethods.EncryptPassword(userAccount.Password);

            DeleteAccount(id);

            //Iterates through all the emails and assigns them with their respective user id 
            //and refterm id

            foreach (Email email in user.Emails)
            {
                email.UserId = user.Id;

                email.RefTermId = ServiceHelperMethods.GetRefTermId(userAccount.Emails
                    .Where(a => a.EmailAddress == email.EmailAddress)
                    .Select(a => a.Type).SingleOrDefault().ToString(), _context);
            }

            //Iterates through all the addresses and assigns them with their respective user id 
            //and refterm id

            foreach (Address address in user.Addresses)
            {
                address.UserId = user.Id;

                address.RefTermId = ServiceHelperMethods.GetRefTermId(userAccount.Addresses
                    .Where(a => a.Line1 == address.Line1 && a.Line2 == address.Line2)
                    .Select(a => a.Type).SingleOrDefault().ToString(), _context);
            }

            //Iterates through all the phones and assigns them with their respective user id 
            //and refterm id

            foreach (Phone phone in user.Phones)
            {
                phone.UserId = user.Id;

                phone.RefTermId = ServiceHelperMethods.GetRefTermId(userAccount.Phones
                    .Where(a => a.PhoneNumber == phone.PhoneNumber)
                    .Select(a => a.Type).SingleOrDefault().ToString(), _context);
            }

            _context.User.Add(user);
            _context.SaveChanges();
        }


        /// <summary>
        /// Deletes a user profile from the database
        /// </summary>
        /// <param name="userId"></param>

        public void DeleteAccount(Guid userId)
        {
            User user = _context.User.Where(a => a.Id == userId).FirstOrDefault();
            _context.User.Remove(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// Checks if an account exists in the database with the user name and email for the object of type UserCreateDto
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>

        public Tuple<bool, string> AccountExists(UserCreateDto account)
        {
            if (_context.User.Any(a => a.UserName == account.UserName))
                return Tuple.Create(true, "Username already exists");

            foreach (EmailCreateDto email in account.Emails)
            {
                if (_context.Email.Any(a => a.EmailAddress == email.EmailAddress))
                    return Tuple.Create(true, "Email address already exists");
            }
            return Tuple.Create(false, "");
        }

        /// <summary>
        /// Checks if an account exists in the database with their user name and email for the object of type UserUpdateDto
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>

        public Tuple<bool, string> AccountExists(Guid userId, UserUpdateDto account)
        {
            //Checks if the user is updating his address book with the same username as before and
            //does nothing if the operation is successful

            if (_context.User.Any(a => a.UserName == account.UserName && a.Id == userId)) ;

            //Else, if the user provided a new username and if that username already exists in the database
            //Then returns false and terminates the account being created

            else if (_context.User.Any(a => a.UserName == account.UserName))
                return Tuple.Create(true, "Username already exists");

            foreach (EmailUpdateDto email in account.Emails)
            {
                //Checks if the user is updating his address book with the same email as before and
                //does nothing if the operation is successful

                if (_context.Email.Any(a => a.EmailAddress == email.EmailAddress && a.UserId == userId)) ;

                //Else, if the user provided a new email and if that email already exists in the database
                //Then returns false and terminates the account being created

                else if (_context.Email.Any(a => a.EmailAddress == email.EmailAddress))
                    return Tuple.Create(true, "Email address already exists");
            }

            return Tuple.Create(false, "");
        }

        /// <summary>
        /// Checks for the metadata given by the user in the database for the object of type UserCreateDto
        /// </summary>
        /// <returns></returns>

        public bool MetaDataExists(UserCreateDto userAccount)
        {
            //Checks metadata given by the user for the "emails" property

            foreach (EmailCreateDto email in userAccount.Emails)
            {
                if (!_context.RefTerm.Any(a => a.Key == email.Type))
                    return false;
            }

            //Checks metadata given by the user for the "addresses" property

            foreach (AddressCreateDto address in userAccount.Addresses)
            {
                if (!_context.RefTerm.Any(a => a.Key == address.Type))
                    return false;
            }

            //Checks metadata given by the user for the "phones" property

            foreach (PhoneCreateDto phone in userAccount.Phones)
            {
                if (!_context.RefTerm.Any(a => a.Key == phone.Type))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Checks for the metadata given by the user in the database for the object of type UserUpdateDto
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>

        public bool MetaDataExists(UserUpdateDto userAccount)
        {
            //Checks metadata given by the user for the "emails" property

            foreach (EmailUpdateDto email in userAccount.Emails)
            {
                if (!_context.RefTerm.Any(a => a.Key == email.Type))
                    return false;
            }

            //Checks metadata given by the user for the "addresses" property

            foreach (AddressUpdateDto address in userAccount.Addresses)
            {
                if (!_context.RefTerm.Any(a => a.Key == address.Type))
                    return false;
            }

            //Checks metadata given by the user for the "phones" property

            foreach (PhoneUpdateDto phone in userAccount.Phones)
            {
                if (!_context.RefTerm.Any(a => a.Key == phone.Type))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Stores the byte[] form of a file in the database
        /// </summary>
        /// <param name="file"></param>
        /// <param name="userId"></param>

        public UploadFileResponseDto UploadFile(IFormFile file, Guid userId)
        {
            byte[] fileBytes = null;

            //Converts a file of any type to byte[] to store in the database

            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            //Gets the file extension and finds the equivalent ref term id

            string fileExtension = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1);
            Guid refTermId = ServiceHelperMethods.GetRefTermId(fileExtension, _context);

            //Creates a new asset object and stores in the database

            Asset asset = new Asset()
            {
                Id = Guid.NewGuid(),
                Content = fileBytes,
                ContentType = file.ContentType,
                UserId = userId,
                RefTermId = refTermId
            };

            _context.Asset.Add(asset);

            _context.SaveChanges();

            //Creates an object of type UploadFileResponseDto for the response

            UploadFileResponseDto uploadFileResponse = new UploadFileResponseDto()
            {
                Id = asset.Id,
                UserId = userId,
                FileName = file.FileName,
                ContentType = file.ContentType,
                Extension = fileExtension
            };

            return uploadFileResponse;
        }

        /// <summary>
        /// Validates the requested file from user against their user id
        /// </summary>
        /// <param name="assetId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>

        public bool ValidateAssetId(Guid assetId, Guid userId)
        {
            return _context.Asset.Any(a => a.Id == assetId && a.UserId == userId);
        }

        /// <summary>
        /// Retrieves and returns a stored file with its content type from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Tuple<byte[], string> DownloadFile(Guid id)
        {
            //Get file content as a byte[]

            byte[] fileContent = _context.Asset.Where(a => a.Id == id).Select(a => a.Content).FirstOrDefault();

            //Get content type of the file

            string contentType = _context.Asset.Where(a => a.Id == id).Select(a => a.ContentType).FirstOrDefault();

            return Tuple.Create(fileContent, contentType);
        }
    }
}