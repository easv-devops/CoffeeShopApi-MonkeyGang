using Models;
using Presentation.DTOs;

namespace Service;

public interface ICustomerService
{
    CustomerDto GetCustomerById(Guid id);
    List<CustomerDto> GetAllCustomers();
    void AddCustomer(CustomerDto customerDto);
    void UpdateCustomer(CustomerDto customerDto);
    void DeleteCustomer(Guid id);
}