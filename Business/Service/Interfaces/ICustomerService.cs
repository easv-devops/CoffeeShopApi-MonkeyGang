using Models;
using Models.DTOs;

namespace Service;

public interface ICustomerService
{
    Task<CustomerDto> GetCustomerAsync(Guid id);
    Task<List<CustomerDto>> GetAllCustomersAsync();
    Task<Guid> AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(CustomerDto customerDto);
    Task DeleteCustomerAsync(Guid id);
}