using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Requests;

public class CreateUserRequest
{
    [Required]
    [StringLength(maximumLength: 128 , MinimumLength = 3)]
    public required string Name { get; set; }

    [FromBody]
    [Required]
    [StringLength(maximumLength: 128 , MinimumLength = 3)]
    public required string LastName { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
}