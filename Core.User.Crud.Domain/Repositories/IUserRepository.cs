using Core.User.Crud.Domain.Entities;

namespace Core.User.Crud.Domain.Repositories;

public interface IUserRepository
{
    Task<UserEntity> GetAsync(Guid id);
    Task<List<UserEntity>> GetAllAsync();
    Task<UserEntity> CreateAsync(UserEntity user);
    Task<UserEntity> UpdateAsync(UserEntity user);
    Task<UserEntity> DeleteAsync(Guid id);
    
}