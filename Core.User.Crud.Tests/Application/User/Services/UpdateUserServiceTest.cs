using Core.User.Crud.Application.User.Commands;
using Core.User.Crud.Application.User.Requests;
using Core.User.Crud.Application.User.Services;
using Core.User.Crud.Domain.Configs;
using Core.User.Crud.Domain.Entities;
using Core.User.Crud.Domain.Factories;
using Core.User.Crud.Domain.Params;
using Core.User.Crud.Infra.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Tests.Application.User.Services;

public class UpdateUserServiceTest
{
    [Fact]
    public async void ShouldUpdateUserWhenUserExists()
    {
        // Arrange
        var userRepository = new UserRepository();
        var userSettings = new UserSettings()
        {
            MinAge = 18
        };
        var updateUserService = new UpdateUserService(userRepository, userSettings);
        var user = UserFactory.Create("John", "Doe", new DateTime(1990, 1, 1), "test@gmail.com");
        var userOnDb = await userRepository.CreateAsync(user);
        var request = new UpdateUserRequest()
        {
            FirstName = "John2",
            LastName = "Doe2",
            DateOfBirth = new DateTime(1990, 1, 1),
            Email = "test@gmail.com"
        };
        var @params = new UpdateUserParams()
        {
            Id = userOnDb.Id
        };
        var command = new UpdateUserCommand().WithRequest(request).WithId(@params.Id);
        var userUpdated =
            (UserEntity)UserFactory.Create(request.FirstName, request.LastName, request.DateOfBirth, request.Email);
        userUpdated.Id = userOnDb.Id;
        // Act
        var result = await updateUserService.ProcessAsync(command);
        // Assert
        result.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeEquivalentTo(userUpdated);
    }
}