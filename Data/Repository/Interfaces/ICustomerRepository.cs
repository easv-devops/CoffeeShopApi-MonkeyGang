using Models;

namespace Data.Repository;

public interface ICustomerRepository
{
    Task<Customer> GetCustomerByIdAsync(Guid id);
    Task<List<Customer>> GetAllCustomersAsync();
    Task<Guid> AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(Guid id);
}