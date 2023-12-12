using Models;
using Models.DTOs;
using Models.DTOs.Response;

namespace Service;

public interface ICustomerService
{
    Task<CustomerDto> GetCustomerAsync(Guid id);
    Task<List<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto> AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(CustomerDto customerDto);
    Task DeleteCustomerAsync(Guid id);
}