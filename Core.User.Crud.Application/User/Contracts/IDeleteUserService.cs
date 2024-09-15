using Core.User.Crud.Domain.commands;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Contracts;

public interface IDeleteUserService
{
    Task<IActionResult> ProcessAsync(DeleteUserCommand command);
}