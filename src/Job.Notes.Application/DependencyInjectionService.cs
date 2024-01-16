﻿using AutoMapper;
using Job.Notes.Application.Configuration;
using Job.Notes.Application.Interfaces.User.Commands.CreateUser;
using Job.Notes.Application.Interfaces.User.Commands.DeleteUser;
using Job.Notes.Application.Interfaces.User.Commands.UpdateUser;
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

        // User
        services.AddTransient<ICreateUserCommand, CreateUserCommand>();
        services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
        services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();

        return services;
    }
}