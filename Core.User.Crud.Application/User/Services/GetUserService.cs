using Core.User.Crud.Application.User.Contracts;
using Core.User.Crud.Domain.commands;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Services;

public class GetUserService: IGetUserService
{
    
    public async Task<IActionResult> ProcessAsync(GetUserCommand command)
    {
        
        
        return new OkResult();
    }
}