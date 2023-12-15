using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTOs.Create;

namespace Data.Repository;

public class UserRepository : IUserRepository
{
    private readonly CoffeeShopDbContext _dbContext;

    public UserRepository(CoffeeShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _dbContext.Users.Include(ex => ex.Orders).ToListAsync();
    }

    public async Task<User> AddUserAsync(User user)    
    {
        
        //check if email is already in use
        var existingUser = await GetUserByEmailAsync(user.Email);
        if (existingUser != null)
        {
            throw new Exception("Email already in use.");
        }
        
        //hash password

        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        
        return user;
    }

    public async Task UpdateUserAsync(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var customer = await _dbContext.Users.FindAsync(id);
        if (customer != null)
        {
            _dbContext.Users.Remove(customer);
            await _dbContext.SaveChangesAsync();
        }
    }
    
    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(c => c.Email == email);
    }
    
    
}