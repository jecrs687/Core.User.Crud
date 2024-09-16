using Core.User.Crud.Application.User.Commands;
using Core.User.Crud.Domain.Exceptions.User;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Contracts;

public interface IGetUserService
{   
    Task<IActionResult> ProcessAsync(GetUserCommand command);
    Task<IActionResult> ProcessAllAsync(GetUsersCommand command);
    
}   