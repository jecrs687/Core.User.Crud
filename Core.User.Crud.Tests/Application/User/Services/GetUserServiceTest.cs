using Core.User.Crud.Application.User.Commands;
using Core.User.Crud.Application.User.Services;
using Core.User.Crud.Domain.Exceptions.User;
using Core.User.Crud.Domain.Factories;
using Core.User.Crud.Domain.Params;
using Core.User.Crud.Infra.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Tests.Application.User.Services;

public class GetUserServiceTest
{
    [Fact]
    public async void ShouldReturnUserWhenUserExists()
    {
        // Arrange
        var userRepository = new UserRepository();
        var getUserService = new GetUserService(userRepository);
        var user = UserFactory.Create("John", "Doe", new DateTime(1990, 1, 1), "test@gmail.com");
        var userOnDb = await userRepository.CreateAsync(user);
        var request = new GetUserParams()
        {
            Id = userOnDb.Id
        };
        var command = new GetUserCommand().WithId(request.Id);
        // Act
        var result = await getUserService.ProcessAsync(command);
        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }
    
    [Fact]
    public async void ShouldReturnNotFoundObjectResultWhenUserDoesNotExists()
    {
        // Arrange
        var userRepository = new UserRepository();
        var getUserService = new GetUserService(userRepository);
        var request = new GetUserParams()
        {
            Id = Guid.NewGuid()
        };
        var command = new GetUserCommand().WithId(request.Id);
        // Act
        Func<Task> act = async () => await getUserService.ProcessAsync(command);
        // Assert
        await act.Should().ThrowAsync<UserNotFoundException>();
    }
    
  
    
}