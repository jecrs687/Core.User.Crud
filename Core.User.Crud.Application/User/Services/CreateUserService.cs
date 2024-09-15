using Core.User.Crud.Application.User.Contracts;
using Core.User.Crud.Domain.commands;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Services;

public class CreateUserService: ICreateUserService
{
    public async Task<IActionResult> ProcessAsync(CreateUserCommand command)
    {
        
        
        return new OkResult();
    }
}