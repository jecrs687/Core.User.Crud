using Core.User.Crud.Api.Extensions;
using Core.User.Crud.Api.Filters;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddSwagger()
    .AddEndpointsApiExplorer()
    .AddHealthCheck()
    .AddServices()
    .AddInfra()
    .AddAppSettings(builder.Configuration)
    .AddControllers(options =>
    {
        options.Filters.Add(new GlobalExceptionFilter());
    });

var app = builder.Build();
app.ConfigureHealthCheck();


if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger();
}

// app.UseAuthorization();

app.MapControllers();

app.Run();