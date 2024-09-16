using Core.User.Crud.Application.User.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Contracts;

public interface IDeleteUserService
{
    Task<IActionResult> ProcessAsync(DeleteUserCommand command);
}