using Core.User.Crud.Domain.Entities;

namespace Core.User.Crud.Domain.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Email { get; set; }

}