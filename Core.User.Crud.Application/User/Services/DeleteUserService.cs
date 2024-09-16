using Core.User.Crud.Application.User.Commands;
using Core.User.Crud.Application.User.Contracts;
using Core.User.Crud.Domain.Exceptions.User;
using Core.User.Crud.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Services;

public class DeleteUserService(IUserRepository userRepository) : IDeleteUserService
{
    public async Task<IActionResult> ProcessAsync(DeleteUserCommand command)
    {
        var response = await userRepository.DeleteAsync(command.Id);
        
        if(response == null)
            return new UserNotFoundException(command.Id);

        return new OkObjectResult(response);
    }
    
}