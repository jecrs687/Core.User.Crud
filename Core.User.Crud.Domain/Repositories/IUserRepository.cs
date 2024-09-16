using Core.User.Crud.Domain.Entities;
using Core.User.Crud.Domain.Models;

namespace Core.User.Crud.Domain.Repositories;

public interface IUserRepository
{
    Task<UserModel?>? GetAsync(Guid id);
    Task<List<UserModel>> GetAllAsync(int page, int pageSize);
    Task<UserModel> CreateAsync(UserEntity user);
    Task<UserModel> UpdateAsync(UserEntity user);
    Task<UserModel> DeleteAsync(Guid id);
    
}