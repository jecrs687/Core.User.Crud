using Core.User.Crud.Domain.Configs;

namespace Core.User.Crud.Api.Extensions;

public static class AddSettings
{
    public static IServiceCollection AddAppSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var userSettings = new UserSettings();
        configuration.GetSection(nameof(UserSettings)).Bind(userSettings);
        services.AddSingleton<UserSettings>(userSettings);
        return services;
    }
}
