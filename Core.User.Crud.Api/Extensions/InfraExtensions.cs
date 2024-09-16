using Core.User.Crud.Domain.Repositories;
using Core.User.Crud.Infra.Repositories;

namespace Core.User.Crud.Api.Extensions;

public static class InfraExtensions
{
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, UserRepository>();
        return services;
    }
}