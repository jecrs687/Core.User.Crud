using Core.User.Crud.Application.User.Commands;
using Core.User.Crud.Application.User.Contracts;
using Core.User.Crud.Application.User.QueryParams;
using Core.User.Crud.Application.User.Requests;
using Core.User.Crud.Domain.Params;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Api.Controllers;

[ApiController]
[Route("API/", Name = "user")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;
    private readonly IGetUserService _getUserService;
    private readonly ICreateUserService _createUserService;
    private readonly IUpdateUserService _updateUserService;
    private readonly IDeleteUserService _deleteUserService;
    
    
    public UserController(ILogger<UserController> logger, IGetUserService getUserService, ICreateUserService createUserService, IUpdateUserService updateUserService, IDeleteUserService deleteUserService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _getUserService = getUserService ?? throw new ArgumentNullException(nameof(getUserService));
        _createUserService = createUserService ?? throw new ArgumentNullException(nameof(createUserService));
        _updateUserService = updateUserService ?? throw new ArgumentNullException(nameof(updateUserService));
        _deleteUserService = deleteUserService ?? throw new ArgumentNullException(nameof(deleteUserService));
    }
    [HttpGet("users")]
    public async Task<IActionResult> Get([FromQuery] GetUsersQueryParam queryParam)
    {
        var command = new GetUsersCommand()
        {
            page = queryParam.page,
            pageSize = queryParam.pageSize
        };
        return await _getUserService.ProcessAllAsync(command);
    }
    [HttpGet("users/{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetUserParams @params)
    {
        var command = new GetUserCommand().WithId(@params.Id);
        
        return await _getUserService.ProcessAsync(command);
    }
    [HttpDelete("users/{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteUserParams @params)
    {
        var command = new DeleteUserCommand().WithId(@params.Id);
        
        return await _deleteUserService.ProcessAsync(command);
    }
    [HttpPost("users")]
    public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
    {
        var command = new CreateUserCommand().WithRequest(request);
        
       return await _createUserService.ProcessAsync(command);
    }
    [HttpPut("users/{Id}")]
    public async Task<IActionResult> Put([FromRoute] UpdateUserParams @params, [FromBody] UpdateUserRequest request)
    {
        var command = new UpdateUserCommand().WithId(@params.Id).WithRequest(request);
        
        return await _updateUserService.ProcessAsync(command);
    }
}