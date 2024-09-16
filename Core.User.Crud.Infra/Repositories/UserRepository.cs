using Core.User.Crud.Domain.Entities;
using Core.User.Crud.Domain.Exceptions.User;
using Core.User.Crud.Domain.Factories;
using Core.User.Crud.Domain.Models;
using Core.User.Crud.Domain.Repositories;

namespace Core.User.Crud.Infra.Repositories;

public class UserRepository : IUserRepository
{
     private List<UserModel> _users = new();
    
    public UserRepository()
    {
        _users.Add(UserFactory.Create("John", "Doe", new DateTime(1990, 1, 1), "JohnDoe@gmail.com"));
    }

    public Task<UserModel?> GetAsync(Guid id)
    {
        var user = _users.Find(x => x.Id == id);
        if(user==null)
            return Task.FromResult<UserModel?>(null);
        return Task.FromResult(user);
    }

    public Task<List<UserModel>> GetAllAsync(int page, int pageSize)
    {
        return Task.FromResult(_users.Skip(page * pageSize).Take(pageSize).ToList());
    }

    public Task<UserModel> CreateAsync(UserEntity user)
    {
        var userOnDb = _users.Find(x => x.Email == user.Email);
        if (userOnDb != null)
            throw new UserAlreadyExistsException(user.Email);
        
        var userToSave = UserFactory.Create(user.FirstName, user.LastName, (DateTime)user.DateOfBirth, user.Email?.ToLower());
        _users.Add(userToSave);
        
        return Task.FromResult(userToSave);
    }

    public Task<UserModel> UpdateAsync(UserEntity user)
    {
        var userToUpdate = _users.Find(x => x.Id == user.Id);
        if(userToUpdate == null)
            return Task.FromResult<UserModel>(null);
        _users.Remove(userToUpdate);
        userToUpdate.FirstName = user.FirstName ?? userToUpdate.FirstName;
        userToUpdate.LastName = user.LastName ?? userToUpdate.LastName;
        userToUpdate.Email = user.Email?.ToLower() ?? userToUpdate.Email;
        userToUpdate.DateOfBirth = user.DateOfBirth ?? userToUpdate.DateOfBirth;
        _users.Add(userToUpdate);
        return Task.FromResult(userToUpdate);

    }

    public Task<UserModel> DeleteAsync(Guid id)
    {
        var userToDelete = _users.Find(x => x.Id == id);
        if(userToDelete == null)
            return Task.FromResult<UserModel>(null);
        _users.Remove(userToDelete);
        return Task.FromResult(userToDelete);
    }
}