using Microsoft.OpenApi.Models;

namespace Core.User.Crud.Api.Extensions;

public static class SwaggerExtensions
{

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(
            c=> c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "User Crud", 
                Version = "v1",
                Description = "User Crud API"
            })
            );
        return services;
    }
    public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
    
}