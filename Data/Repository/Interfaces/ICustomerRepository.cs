using Models;

namespace Data.Repository;

public interface ICustomerRepository
{
    Customer GetCustomerById(Guid customerId);
    IEnumerable<Customer> GetAllCustomers();
    void AddCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    void DeleteCustomer(Guid customerId);
}