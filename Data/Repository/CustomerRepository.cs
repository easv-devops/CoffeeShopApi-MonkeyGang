using Models;

namespace Data.Repository;

public class CustomerRepository : ICustomerRepository
{
    private List<Customer> customers = new List<Customer>();

    public Customer GetCustomerById(Guid customerId)
    {
        return customers.FirstOrDefault(c => c.CustomerID == customerId);
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return customers;
    }

    public void AddCustomer(Customer customer)
    {
        customers.Add(customer);
    }

    public void UpdateCustomer(Customer customer)
    {
        // Implementation to update a customer in the database
    }

    public void DeleteCustomer(Guid customerId)
    {
        customers.RemoveAll(c => c.CustomerID == customerId);
    }
}