using Core.User.Crud.Domain.Entities;

namespace Core.User.Crud.Domain.Factories;

public class UserFactory
{
    public static UserEntity Create(string firstName, string lastName, DateTime dateOfBirth)
    {
        return new UserEntity
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth
        };
    }
    
    public static List<UserEntity> CreateList(List<string> firstNames, List<string> lastNames, List<DateTime> dateOfBirths)
    {
        var users = new List<UserEntity>();
        for (var i = 0; i < firstNames.Count; i++)
        {
            users.Add(new UserEntity
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