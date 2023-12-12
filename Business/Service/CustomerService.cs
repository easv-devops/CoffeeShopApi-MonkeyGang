using AutoMapper;
using Data.Repository;
using Models;
using Models.DTOs;
using Models.DTOs.Create;
using Models.DTOs.Response;

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

    public async Task<CustomerDto> GetCustomerAsync(Guid id)
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

    public async Task<CustomerDto> AddCustomerAsync(Customer customer)
    {
        await _customerRepository.AddCustomerAsync(customer);
        
        return _mapper.Map<CustomerDto>(customer);

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