
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
public class UserServiceTests
{
    private Mock<CoffeeShopDbContext> _dbContextMock;
    IMapper _mapper;
    private Mock<IUserRepository> _customerRepositoryMock;
    private IUserService _userService;

    [SetUp]
    public void Setup()
    {
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        }).CreateMapper();
        _customerRepositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_mapper, _customerRepositoryMock.Object);
        _dbContextMock = new Mock<CoffeeShopDbContext>();
    }

    [Test]
    public async Task AddUserAsync_ShouldReturnGeneratedId()
    {
        // Arrange
        var customer = new User
        {
            // Set other properties if needed...
        };

        var expectedId = Guid.NewGuid();
        customer.UserId = expectedId; // Set the expectedId in the customer object
        _customerRepositoryMock.Setup(repo => repo.AddUserAsync(customer))
            .ReturnsAsync(customer);

        // Act
        UserDto dto = await _userService.AddUserAsync(customer);

        // Assert
        Assert.That(expectedId, Is.EqualTo(dto.UserId));
    }


    [Test]
    public async Task GetUserAsync_ShouldReturnUser()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var expectedUser = new User
        {
            // Set customer properties as needed
            UserId = customerId
        };

        _customerRepositoryMock.Setup(repo => repo.GetUserByIdAsync(customerId))
            .ReturnsAsync(expectedUser);

        // Act
        var result = await _userService.GetUserAsync(customerId);

        // Assert
        Assert.That(result, Is.Not.Null);        
        Assert.That(customerId, Is.EqualTo(result.UserId));
    }

    [Test]
    public async Task GetUserAsync_ShouldReturnNullIfUserNotFound()
    {
        // Arrange
        var nonExistentUserId = Guid.NewGuid();

        _customerRepositoryMock.Setup(repo => repo.GetUserByIdAsync(nonExistentUserId))
            .ReturnsAsync((User)null);

        // Act
        var result = await _userService.GetUserAsync(nonExistentUserId);

        // Assert
        Assert.That(result, Is.Null);    }
    
    [Test]
    public async Task CanHashAndVerifyPasswordAsync()
    {
        // Arrange
        string email = "test@example.com";
        string password = "secretpassword";

        // Set up mock behavior for RegisterUserAsync
        _customerRepositoryMock.Setup(repo => repo.AddUserAsync(It.IsAny<User>()))
            .ReturnsAsync((User)null); // Adjust the return value based on your implementation

        // Set up mock behavior for IsCorrectPasswordAsync
        _customerRepositoryMock.Setup(repo => repo.GetUserByEmailAsync(email))
            .ReturnsAsync(new User() { Email = email, Password = BCrypt.Net.BCrypt.HashPassword(password) });

        // Act
        UserDto registrationResult = await _userService.AddUserAsync(new User() { Email = email, Password = password });
        bool verificationResult = _userService.VerifyPasswordAsync(email, password);

        
        if (registrationResult == null)
        {
            Assert.Fail("User registration should succeed.");
        }
        
        Assert.That(verificationResult, Is.True);
        _customerRepositoryMock.Verify(repo => repo.AddUserAsync(It.IsAny<User>()), Times.Once);
        _customerRepositoryMock.Verify(repo => repo.GetUserByEmailAsync(It.IsAny<string>()), Times.Once);
    }
    
    
}
