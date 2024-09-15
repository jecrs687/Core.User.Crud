using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Requests;

public class UpdateUserRequest
{
    [StringLength(maximumLength: 128 , MinimumLength = 3)]
    public required string Name { get; set; }

    [StringLength(maximumLength: 128 , MinimumLength = 3)]
    public required string LastName { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    
    [EmailAddress]
    public required string Email { get; set; }
}