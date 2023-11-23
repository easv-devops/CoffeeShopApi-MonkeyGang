using AutoMapper;
using Data.Repository;
using Models;
using Presentation.DTOs;

namespace Service;

public class CustomerService : ICustomerService
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public CustomerDto GetCustomerById(Guid id)
    {
        var customer = _customerRepository.GetCustomerById(id);
        return _mapper.Map<CustomerDto>(customer);
    }

    public List<CustomerDto> GetAllCustomers()
    {
        var customers = _customerRepository.GetAllCustomers();
        return _mapper.Map<List<CustomerDto>>(customers);
    }

    public void AddCustomer(CustomerDto customerDto)
    {
        var customer = _mapper.Map<Customer>(customerDto);
        _customerRepository.AddCustomer(customer);
    }

    public void UpdateCustomer(CustomerDto customerDto)
    {
        var customer = _mapper.Map<Customer>(customerDto);
        _customerRepository.UpdateCustomer(customer);
    }

    public void DeleteCustomer(Guid id)
    {
        _customerRepository.DeleteCustomer(id);
    }
}