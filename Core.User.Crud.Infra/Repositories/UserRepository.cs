using Core.User.Crud.Domain.Entities;
using Core.User.Crud.Domain.Factories;
using Core.User.Crud.Domain.Repositories;

namespace Core.User.Crud.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private List<UserEntity> _users = new();
    
    public UserRepository()
    {
        _users.Add(UserFactory.Create("John", "Doe", new DateTime(1990, 1, 1)));
    }

    public Task<UserEntity> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity> CreateAsync(UserEntity user)
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity> UpdateAsync(UserEntity user)
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}