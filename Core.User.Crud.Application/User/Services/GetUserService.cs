using Core.User.Crud.Application.User.Commands;
using Core.User.Crud.Application.User.Contracts;
using Core.User.Crud.Domain.Entities;
using Core.User.Crud.Domain.Exceptions.User;
using Core.User.Crud.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Services;

public class GetUserService(IUserRepository userRepository) : IGetUserService
{
    public async Task<IActionResult> ProcessAsync(GetUserCommand command)
    {
        var user = await userRepository.GetAsync(command.Id);
        if (user == null)
            throw new UserNotFoundException(command.Id);

        return new OkObjectResult((UserEntity)user);
    }
    public async Task<IActionResult> ProcessAllAsync(GetUsersCommand command)
    {
        var users = await userRepository.GetAllAsync(command.page, command.pageSize);
        return new OkObjectResult(users.Select(x => (UserEntity)x).ToList());
    }
}
