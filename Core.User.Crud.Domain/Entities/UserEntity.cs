using Core.User.Crud.Domain.Models;
using Core.User.Crud.Domain.Utils;
namespace Core.User.Crud.Domain.Entities;

public class UserEntity
{
    public Guid? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    
    public string? Email { get; set; }
    
    public int? Age { get; set; }

    public int CalculateAge()
    {
        if(DateOfBirth == null)
            return 0;
        return DateTimeUtils.YearsBetween((DateTime)DateOfBirth, DateTime.Now);
    }
    
    public static implicit operator UserEntity?(UserModel userModel)
    {
        if (userModel == null)
            return null;
        return new UserEntity
        {
            Id = userModel.Id,
            FirstName = userModel.FirstName,
            LastName = userModel.LastName,
            DateOfBirth = userModel.DateOfBirth,
            Email = userModel.Email,
            Age = DateTimeUtils.YearsBetween(userModel.DateOfBirth, DateTime.Now)
        };
    }
}