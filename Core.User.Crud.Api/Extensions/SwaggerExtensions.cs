namespace Core.User.Crud.Api.Extensions;

public static class SwaggerExtensions
{

    public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
    
}