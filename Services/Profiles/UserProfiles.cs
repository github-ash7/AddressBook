using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace Services.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            //Maps create dtos to model

            CreateMap<UserCreateDto, User>();
            CreateMap<EmailCreateDto, Email>();
            CreateMap<AddressCreateDto, Address>();
            CreateMap<PhoneCreateDto, Phone>();

            //Maps model to response dtos

            CreateMap<User, UserResponseDto>();
            CreateMap<Email, EmailResponseDto>();
            CreateMap<Address, AddressResponseDto>();
            CreateMap<Phone, PhoneResponseDto>();

            //Maps update dtos to model

            CreateMap<UserUpdateDto, User>();
            CreateMap<EmailUpdateDto, Email>();
            CreateMap<AddressUpdateDto, Address>();
            CreateMap<PhoneUpdateDto, Phone>();

        }
    }
}
