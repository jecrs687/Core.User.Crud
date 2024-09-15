using Core.User.Crud.Application.User.Contracts;
using Core.User.Crud.Domain.commands;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Services;

public class DeleteUserService:IDeleteUserService
{    
    public async Task<IActionResult> ProcessAsync(DeleteUserCommand command)
    {
        
        
        return new OkResult();
    }
    
}