using Models;
using Models.DTOs;

namespace Service;

public interface ICustomerService
{
    Task<CustomerDto> GetCustomerByIdAsync(Guid id);
    Task<List<CustomerDto>> GetAllCustomersAsync();
    Task AddCustomerAsync(CustomerDto customerDto);
    Task UpdateCustomerAsync(CustomerDto customerDto);
    Task DeleteCustomerAsync(Guid id);
}