using Models;

namespace Data.Repository;

public interface ICustomerRepository
{
    Task<Customer> GetCustomerByIdAsync(Guid id);
    Task<List<Customer>> GetAllCustomersAsync();
    Task AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(Guid id);
}