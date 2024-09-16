using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Application.User.Requests;

public class CreateUserRequest
{
    [Required]
    [StringLength(maximumLength: 128 , MinimumLength = 3, ErrorMessage = "Name must be between 3 and 128 characters")]
    public required string FirstName { get; set; }

    [FromBody]
    [Required]
    [StringLength(maximumLength: 128 , MinimumLength = 3, ErrorMessage = "Last name must be between 3 and 128 characters")]
    public required string LastName { get; set; }
    
    [Required]
    [DataType(DataType.Date, ErrorMessage = "Date of birth must be a valid date" )]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    [EmailAddress(ErrorMessage = "Email must be a valid email address")]
    public required string Email { get; set; }
}