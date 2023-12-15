using AutoMapper;
using Data.Repository;
using Models;
using Models.DTOs;
using Models.DTOs.Create;
using Models.DTOs.Response;

namespace Service;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _customerRepository;


    //todo: add logging
    public UserService(IMapper mapper, IUserRepository customerRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<UserDto> GetUserAsync(Guid id)
    {
        try
        {
            var customer = await _customerRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDto>(customer);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        try
        {
            var customers = await _customerRepository.GetAllUsersAsync();
            return _mapper.Map<List<UserDto>>(customers);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<UserDto> AddUserAsync(User user)
    {
        
        await _customerRepository.AddUserAsync(user);
        
        return _mapper.Map<UserDto>(user);

    }

    public async Task UpdateUserAsync(UserDto userDto)
    {
        try
        {
            var customer = _mapper.Map<User>(userDto);
            await _customerRepository.UpdateUserAsync(customer);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task DeleteUserAsync(Guid id)
    {
        try
        {
            await _customerRepository.DeleteUserAsync(id);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    
    public async Task<UserDto> GetUserByEmailAsync(string email)
    {
        try
        {
            var customer = await _customerRepository.GetUserByEmailAsync(email);
            return _mapper.Map<UserDto>(customer);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    
    public bool VerifyPasswordAsync(string email, string password)
    {
        // Retrieve user by email
        User user = _customerRepository.GetUserByEmailAsync(email).Result;
        
        // Check if user exists i don't know how to do this ¯\_(ツ)_/¯

        // Verify the password
        
        
        return BCrypt.Net.BCrypt.Verify(password, user.Password);
    }
    
    
}