using Models;
using Models.DTOs.Create;

namespace Data.Repository;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(Guid id);
    Task<List<User>> GetAllUsersAsync();
    Task<User> AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(Guid id);
    
    Task<User> GetUserByEmailAsync(string email);
    
}