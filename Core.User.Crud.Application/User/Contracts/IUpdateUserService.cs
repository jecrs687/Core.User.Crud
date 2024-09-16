using Core.User.Crud.Application.User.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Contracts;

public interface IUpdateUserService
{
    Task<IActionResult> ProcessAsync(UpdateUserCommand command);
}