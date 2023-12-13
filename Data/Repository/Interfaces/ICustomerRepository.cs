using Models;
using Models.DTOs.Create;

namespace Data.Repository;

public interface ICustomerRepository
{
    Task<Customer> GetCustomerByIdAsync(Guid id);
    Task<List<Customer>> GetAllCustomersAsync();
    Task<Customer> AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(Guid id);
    
    Task<Customer> GetCustomerByEmailAsync(string email);
    
}