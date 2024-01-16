using AutoMapper;
using Job.Notes.Application.Interfaces.User.Commands.CreateUser;
using Job.Notes.Application.Interfaces.User.Commands.UpdatePasswordUser;
using Job.Notes.Application.Interfaces.User.Commands.UpdateUser;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Configuration;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<UserEntity, CreateUserModel>().ReverseMap();
        CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
        CreateMap<UserEntity, UpdatePasswordUserCommand>().ReverseMap();
    }
}