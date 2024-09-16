using Core.User.Crud.Domain.Entities;
using Core.User.Crud.Domain.Models;

namespace Core.User.Crud.Domain.Factories;

public class UserFactory
{
    public static UserModel Create(string? firstName, string? lastName, DateTime dateOfBirth, string? email)
    {
        if(firstName == null || lastName == null || email == null || dateOfBirth == null)
            throw new ArgumentNullException();
        return new UserModel
        {
            Id = Guid.NewGuid(),
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth 
        };
    }
    
    public static List<UserModel> CreateList(List<string> firstNames, List<string> lastNames, List<DateTime> dateOfBirths)
    {
        var users = new List<UserModel>();
        for (var i = 0; i < firstNames.Count; i++)
        {
            users.Add(new UserModel
            {
                Id = Guid.NewGuid(),
                FirstName = firstNames[i],
                LastName = lastNames[i],
                DateOfBirth = dateOfBirths[i]
            });
        }

        return users;
    }
    
}