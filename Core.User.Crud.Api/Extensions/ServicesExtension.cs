using Core.User.Crud.Application.User.Contracts;
using Core.User.Crud.Application.User.Services;

namespace Core.User.Crud.Api.Extensions;

public static class ServicesExtension
{
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IGetUserService, GetUserService>();
        // services.AddScoped<ICreateUserService, CreateUserService>();
        // services.AddScoped<IUpdateUserService, UpdateUserService>();
        // services.AddScoped<IDeleteUserService, DeleteUserService>();
        return services;
    }
    
}