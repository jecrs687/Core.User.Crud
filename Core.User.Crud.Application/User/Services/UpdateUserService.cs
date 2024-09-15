using Core.User.Crud.Application.User.Contracts;
using Core.User.Crud.Domain.commands;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Services;

public class UpdateUserService: IUpdateUserService
{
    public async Task<IActionResult> ProcessAsync(UpdateUserCommand command)
    {
        
        
        return new OkResult();
    }
}