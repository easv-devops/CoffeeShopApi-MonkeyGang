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
        _mapper = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); }).CreateMapper();
        _customerRepositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_mapper, _customerRepositoryMock.Object);
        _dbContextMock = new Mock<CoffeeShopDbContext>();
    }

    [Test]
    public async Task AddUserAsync_ShouldReturnGeneratedId()
    {
        var customer = new User
        {
        };

        var expectedId = Guid.NewGuid();
        customer.UserId = expectedId; 
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
        var customerId = Guid.NewGuid();
        var expectedUser = new User
        {
            UserId = customerId
        };

        _customerRepositoryMock.Setup(repo => repo.GetUserByIdAsync(customerId))
            .ReturnsAsync(expectedUser);

        var result = await _userService.GetUserAsync(customerId);

        Assert.That(result, Is.Not.Null);
        Assert.That(customerId, Is.EqualTo(result.UserId));
    }

    [Test]
    public async Task GetUserAsync_ShouldReturnNullIfUserNotFound()
    {
        var nonExistentUserId = Guid.NewGuid();

        _customerRepositoryMock.Setup(repo => repo.GetUserByIdAsync(nonExistentUserId))
            .ReturnsAsync((User)null);

        var result = await _userService.GetUserAsync(nonExistentUserId);

        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task CanHashAndVerifyPasswordAsync()
    {
        string email = "test@example.com";
        string password = "secretpassword";

        _customerRepositoryMock.Setup(repo => repo.AddUserAsync(It.IsAny<User>()))
            .ReturnsAsync((User)null); 

        _customerRepositoryMock.Setup(repo => repo.GetUserByEmailAsync(email))
            .ReturnsAsync(new User() { Email = email, Password = BCrypt.Net.BCrypt.HashPassword(password) });

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