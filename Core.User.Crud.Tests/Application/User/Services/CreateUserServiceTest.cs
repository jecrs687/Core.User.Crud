using Core.User.Crud.Application.User.Commands;
using Core.User.Crud.Application.User.Contracts;
using Core.User.Crud.Application.User.Requests;
using Core.User.Crud.Application.User.Services;
using Core.User.Crud.Domain.Configs;
using Core.User.Crud.Domain.Exceptions.User;
using Core.User.Crud.Domain.Factories;
using Core.User.Crud.Domain.Repositories;
using Core.User.Crud.Infra.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Tests.Application.User.Services;

public class CreateUserServiceTest
{
    private readonly UserSettings userSettings = new()
    {
        MinAge = 18
    };
    [Fact]
    public async void ShouldReturnUserAlreadyExistsExceptionWhenUserAlreadyExists()
    {
        // Arrange
        var userRepository = new UserRepository();
        var createUserService = new CreateUserService(userRepository, userSettings);
        var user = UserFactory.Create("John", "Doe", new DateTime(1990, 1, 1), "test@gmail.com");
        userRepository.CreateAsync(user);
        var request = new CreateUserRequest()
        {
            FirstName = "teste",
            LastName = "teste",
            DateOfBirth = new DateTime(1990, 1, 1),
            Email = "test@gmail.com"
        };
        var command = new CreateUserCommand().WithRequest(request);
        // Act
        Func<Task> act = async () => await createUserService.ProcessAsync(command);
        // Assert
        await act.Should().ThrowAsync<UserAlreadyExistsException>();
    }
    [Fact]
    public async void ShouldReturnOkObjectResultWhenUserIsCreated()
    {
        // Arrange
        var userRepository = new UserRepository();
        var createUserService = new CreateUserService(userRepository, userSettings);
        var request = new CreateUserRequest()
        {
            FirstName = "teste",
            LastName = "teste",
            DateOfBirth = new DateTime(1990, 1, 1),
            Email = "test@gmail.com"
        };
        var command = new CreateUserCommand().WithRequest(request);
        // Act
        var result = await createUserService.ProcessAsync(command);
        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }
    [Fact]
    public async void ShouldReturnBadRequestObjectResultWhenUserIsUnder18()
    {
        // Arrange
        var userRepository = new UserRepository();
        var createUserService = new CreateUserService(userRepository, userSettings);
        var request = new CreateUserRequest()
        {
            FirstName = "teste",
            LastName = "teste",
            DateOfBirth = new DateTime(2020, 1, 1),
            Email = "test@gmail.com"
        };
        var command = new CreateUserCommand().WithRequest(request);
        // Act
        Func<Task> act = async () => await createUserService.ProcessAsync(command);
        // Assert
        await act.Should().ThrowAsync<BirthDateInvalidUnder18Exception>();
    }
    
}