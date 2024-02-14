using AutoMapper;
using Job.Notes.Application.Database.Space.Commands.CreateSpace;
using Job.Notes.Application.Database.Space.Commands.UpdateSpace;
using Job.Notes.Application.Database.Space.Queries.GetSpaceById;
using Job.Notes.Application.Database.Space.Queries.GetSpacesDashboard;
using Job.Notes.Application.Interfaces.User.Commands.CreateUser;
using Job.Notes.Application.Interfaces.User.Commands.UpdatePasswordUser;
using Job.Notes.Application.Interfaces.User.Commands.UpdateUser;
using Job.Notes.Domain.Entities;

namespace Job.Notes.Application.Configuration;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<SpaceEntity, GetSpacesDashboardModel>().ReverseMap();
        CreateMap<SpaceEntity, GetSpaceByIdModel>().ReverseMap();
        CreateMap<SpaceEntity, CreateSpaceModel>().ReverseMap();
        CreateMap<SpaceEntity, UpdateSpaceModel>().ReverseMap();
        
        CreateMap<UserEntity, CreateUserModel>().ReverseMap();
        CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
        CreateMap<UserEntity, UpdatePasswordUserCommand>().ReverseMap();
    }
}