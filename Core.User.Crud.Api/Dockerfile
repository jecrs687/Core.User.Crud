FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Core.User.Crud.Api/Core.User.Crud.Api.csproj", "Core.User.Crud.Api/"]
RUN dotnet restore "Core.User.Crud.Api/Core.User.Crud.Api.csproj"
COPY . .
WORKDIR "/src/Core.User.Crud.Api"
RUN dotnet build "Core.User.Crud.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Core.User.Crud.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Core.User.Crud.Api.dll"]
