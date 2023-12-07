using AutoMapper;
using Data.Repository;
using Models;
using Models.DTOs;

namespace Service;

public class CustomerService : ICustomerService
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;


    //todo: add logging
    public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<CustomerDto> GetCustomerByIdAsync(Guid id)
    {
        try
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            return _mapper.Map<CustomerDto>(customer);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<List<CustomerDto>> GetAllCustomersAsync()
    {
        try
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            return _mapper.Map<List<CustomerDto>>(customers);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task AddCustomerAsync(CustomerDto customerDto)
    {
        try
        {
            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            await _customerRepository.AddCustomerAsync(customer);
        }
        catch (Exception ex)
        {
            // Handle or log the exception
            throw;
        }
    }

    public async Task UpdateCustomerAsync(CustomerDto customerDto)
    {
        try
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.UpdateCustomerAsync(customer);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task DeleteCustomerAsync(Guid id)
    {
        try
        {
            await _customerRepository.DeleteCustomerAsync(id);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}