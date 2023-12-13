using Models;
using Models.DTOs;
using Models.DTOs.Response;
using Models.Utility;

namespace Service;

public interface ICustomerService
{
    Task<CustomerDto> GetCustomerAsync(Guid id);
    Task<List<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto> AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(CustomerDto customerDto);
    Task DeleteCustomerAsync(Guid id);
    
    Task<CustomerDto> GetCustomerByEmailAsync(string email);
    
    bool VerifyPasswordAsync(String email, String password);
    
}