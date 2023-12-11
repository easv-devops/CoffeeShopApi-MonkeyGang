
using AutoMapper;
using Data.Repository;
using Models;
using Moq;
using NUnit.Framework;
using Presentation;
using Service;

[TestFixture]
public class CustomerServiceTests
{
    IMapper _mapper;
    private Mock<ICustomerRepository> _customerRepositoryMock;
    private ICustomerService _customerService;

    [SetUp]
    public void Setup()
    {
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        }).CreateMapper();
        _customerRepositoryMock = new Mock<ICustomerRepository>();
        _customerService = new CustomerService(_mapper, _customerRepositoryMock.Object);
    }

    [Test]
    public async Task AddCustomerAsync_ShouldReturnGeneratedId()
    {
        // Arrange
        var customer = new Customer
        {
            
        };

        var expectedId = Guid.NewGuid();
        _customerRepositoryMock.Setup(repo => repo.AddCustomerAsync(customer))
            .ReturnsAsync(expectedId);

        // Act
        var result = await _customerService.AddCustomerAsync(customer);

        // Assert
        Assert.AreEqual(expectedId, result);
    }


    [Test]
    public async Task GetCustomerAsync_ShouldReturnCustomer()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var expectedCustomer = new Customer
        {
            // Set customer properties as needed
            CustomerId = customerId
        };

        _customerRepositoryMock.Setup(repo => repo.GetCustomerByIdAsync(customerId))
            .ReturnsAsync(expectedCustomer);

        // Act
        var result = await _customerService.GetCustomerAsync(customerId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(customerId, result.CustomerId);
    }

    [Test]
    public async Task GetCustomerAsync_ShouldReturnNullIfCustomerNotFound()
    {
        // Arrange
        var nonExistentCustomerId = Guid.NewGuid();

        _customerRepositoryMock.Setup(repo => repo.GetCustomerByIdAsync(nonExistentCustomerId))
            .ReturnsAsync((Customer)null);

        // Act
        var result = await _customerService.GetCustomerAsync(nonExistentCustomerId);

        // Assert
        Assert.IsNull(result);
    }
}
