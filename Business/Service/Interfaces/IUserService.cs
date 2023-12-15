using Models;
using Models.DTOs;
using Models.DTOs.Response;
using Models.Utility;

namespace Service;

public interface IUserService
{
    Task<UserDto> GetUserAsync(Guid id);
    Task<List<UserDto>> GetAllUsersAsync();
    Task<UserDto> AddUserAsync(User user);
    Task UpdateUserAsync(UserDto userDto);
    Task DeleteUserAsync(Guid id);
    
    Task<UserDto> GetUserByEmailAsync(string email);
    
    bool VerifyPasswordAsync(String email, String password);
    
}