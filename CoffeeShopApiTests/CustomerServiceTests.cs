
using AutoMapper;
using Data;
using Data.Repository;
using Models;
using Models.DTOs;
using Moq;
using NUnit.Framework;
using Presentation;
using Service;

namespace CoffeeShopApiTests;

[TestFixture]
public class CustomerServiceTests
{
    private Mock<CoffeeShopDbContext> _dbContextMock;
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
        _dbContextMock = new Mock<CoffeeShopDbContext>();
    }

    [Test]
    public async Task AddCustomerAsync_ShouldReturnGeneratedId()
    {
        // Arrange
        var customer = new Customer
        {
            // Set other properties if needed...
        };

        var expectedId = Guid.NewGuid();
        customer.CustomerId = expectedId; // Set the expectedId in the customer object
        _customerRepositoryMock.Setup(repo => repo.AddCustomerAsync(customer))
            .ReturnsAsync(customer);

        // Act
        CustomerDto dto = await _customerService.AddCustomerAsync(customer);

        // Assert
        Assert.That(expectedId, Is.EqualTo(dto.CustomerId));
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
        Assert.That(result, Is.Not.Null);        
        Assert.That(customerId, Is.EqualTo(result.CustomerId));
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
        Assert.That(result, Is.Null);    }
    
    [Test]
    public async Task CanHashAndVerifyPasswordAsync()
    {
        // Arrange
        string email = "test@example.com";
        string password = "secretpassword";

        // Set up mock behavior for RegisterUserAsync
        _customerRepositoryMock.Setup(repo => repo.AddCustomerAsync(It.IsAny<Customer>()))
            .ReturnsAsync((Customer)null); // Adjust the return value based on your implementation

        // Set up mock behavior for IsCorrectPasswordAsync
        _customerRepositoryMock.Setup(repo => repo.GetCustomerByEmailAsync(email))
            .ReturnsAsync(new Customer() { Email = email, Password = BCrypt.Net.BCrypt.HashPassword(password) });

        // Act
        CustomerDto registrationResult = await _customerService.AddCustomerAsync(new Customer() { Email = email, Password = password });
        bool verificationResult = _customerService.VerifyPasswordAsync(email, password);

        
        if (registrationResult == null)
        {
            Assert.Fail("User registration should succeed.");
        }
        
        Assert.That(verificationResult, Is.True);
        _customerRepositoryMock.Verify(repo => repo.AddCustomerAsync(It.IsAny<Customer>()), Times.Once);
        _customerRepositoryMock.Verify(repo => repo.GetCustomerByEmailAsync(It.IsAny<string>()), Times.Once);
    }
    
    
}
