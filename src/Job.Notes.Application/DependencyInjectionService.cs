using AutoMapper;
using Job.Notes.Application.Configuration;
using Job.Notes.Application.Database.Project.Commands.ArchiveProject;
using Job.Notes.Application.Database.Project.Commands.CreateProject;
using Job.Notes.Application.Database.Project.Commands.DeleteProject;
using Job.Notes.Application.Database.Project.Commands.UpdateProject;
using Job.Notes.Application.Database.Project.Queries.GetProjectDashboard;
using Job.Notes.Application.Database.Security.Commands.CreateSecurity;
using Job.Notes.Application.Database.Space.Commands.ArchiveSpace;
using Job.Notes.Application.Database.Space.Commands.ChangeStatusSpace;
using Job.Notes.Application.Database.Space.Commands.CreateSpace;
using Job.Notes.Application.Database.Space.Commands.UpdateSpace;
using Job.Notes.Application.Database.Space.Queries.GetSpaceById;
using Job.Notes.Application.Database.Space.Queries.GetSpaces;
using Job.Notes.Application.Database.Space.Queries.GetSpacesDashboard;
using Job.Notes.Application.Database.User.Commands.CreateUser;
using Job.Notes.Application.Database.User.Commands.CreateUsername;
using Job.Notes.Application.Database.User.Commands.DeleteUser;
using Job.Notes.Application.Database.User.Commands.UpdateUser;
using Microsoft.Extensions.DependencyInjection;

namespace Job.Notes.Application;

public static class DependencyInjectionService
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var mapper = new MapperConfiguration(config =>
        {
            config.AddProfile(new MapperProfile());
        });
        services.AddSingleton(mapper.CreateMapper());

        #region Project
        services.AddTransient<IGetProjectDashboard, GetProjectDashboard>();

        services.AddTransient<ICreateProject, CreateProject>();
        services.AddTransient<IUpdateProject, UpdateProject>();
        services.AddTransient<IArchiveProject, ArchiveProject>();
        services.AddTransient<IDeleteProject, DeleteProject>();
        #endregion

        #region Space
        services.AddTransient<IGetSpacesDashboard, GetSpacesDashboard>();
        services.AddTransient<IGetSpaceById, GetSpaceById>();
        services.AddTransient<IGetSpaces, GetSpaces>();

        services.AddTransient<IArchiveSpace, ArchiveSpace>();
        services.AddTransient<IChangeStatusSpaceCommand, ChangeStatusSpaceCommand>();
        services.AddTransient<ICreateSpace, CreateSpace>();
        services.AddTransient<IUpdateSpace, UpdateSpace>();
        #endregion
        
        
        #region User
        services.AddTransient<ICreateUser, CreateUser>();
        services.AddTransient<ICreateUsername, CreateUsername>();
        services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
        services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
        #endregion

        #region Security
        services.AddTransient<ICreateSecurity, CreateSecurity>();
        #endregion
        

        return services;
    }
}