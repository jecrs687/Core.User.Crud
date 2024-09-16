using Core.User.Crud.Application.User.Commands;
using Core.User.Crud.Application.User.Contracts;
using Core.User.Crud.Domain.Configs;
using Core.User.Crud.Domain.Entities;
using Core.User.Crud.Domain.Exceptions.User;
using Core.User.Crud.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Services;

public class UpdateUserService(IUserRepository userRepository, UserSettings userSettings) : IUpdateUserService
{
    public async Task<IActionResult> ProcessAsync(UpdateUserCommand command)
    {
        if ( command.ToEntity().CalculateAge() < userSettings.MinAge)
            return new BirthDateInvalidUnder18Exception();
        var response = await userRepository.UpdateAsync(command.ToEntity());
        if(response == null)
            return new UserNotFoundException(command.Id);


        return new OkObjectResult((UserEntity)response);
    }
}