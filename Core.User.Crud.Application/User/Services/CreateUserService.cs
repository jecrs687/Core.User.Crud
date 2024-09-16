using Core.User.Crud.Application.User.Commands;
using Core.User.Crud.Application.User.Contracts;
using Core.User.Crud.Domain.Configs;
using Core.User.Crud.Domain.Entities;
using Core.User.Crud.Domain.Exceptions.User;
using Core.User.Crud.Domain.Repositories;
using Core.User.Crud.Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Services;

public class CreateUserService(IUserRepository userRepository, UserSettings userSettings) : ICreateUserService
{
    public async Task<IActionResult> ProcessAsync(CreateUserCommand command)
    {
        var user = command.ToEntity();
        if(command.ToEntity().CalculateAge() < userSettings.MinAge)
            throw new BirthDateInvalidUnder18Exception();
        try
        {
            var userDto = await userRepository.CreateAsync(user);
            return new OkObjectResult(userDto);
        }
        catch (Exception e)
        {
            if(e is UserAlreadyExistsException)
                throw new UserAlreadyExistsException(e.Message);
            return new BadRequestObjectResult(e.Message);
        }
    }
}