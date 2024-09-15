using Core.User.Crud.Domain.commands;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Contracts;

public interface IGetUserService
{   
    Task<IActionResult> ProcessAsync(GetUserCommand command);
    
}   