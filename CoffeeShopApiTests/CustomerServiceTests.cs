using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Repository;
using Models;
using Models.DTOs;
using Moq;
using NUnit.Framework;
using Presentation;
using Service;

namespace CoffeeShopApiTests
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private Mock<ICustomerRepository> _customerRepositoryMock;
        private IMapper _mapper;
        private ICustomerService _customerService;

        [SetUp]
        public void SetUp()
        {
            // Setup AutoMapper
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>(); // Update with your actual AutoMapper profile
            });

            _mapper = mapperConfiguration.CreateMapper();

            // Setup Mock Customer Repository
            _customerRepositoryMock = new Mock<ICustomerRepository>();

            // Inject Mock Repository and AutoMapper into CustomerService
            _customerService = new CustomerService(_mapper, _customerRepositoryMock.Object);
        }

        [Test]
        public async Task GetCustomerByIdAsync_ValidCustomerId_ReturnsMappedCustomerDto()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var customer = new Customer { CustomerId = customerId, FirstName = "John", LastName = "Doe" };

            _customerRepositoryMock.Setup(repo => repo.GetCustomerByIdAsync(customerId)).ReturnsAsync(customer);

            // Act
            var result = await _customerService.GetCustomerByIdAsync(customerId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(customerId, result.CustomerId);
            Assert.AreEqual("John", result.FirstName);
            Assert.AreEqual("Doe", result.LastName);
        }

        [Test]
        public async Task GetCustomerByIdAsync_NonexistentCustomerId_ReturnsNull()
        {
            // Arrange
            var nonExistentCustomerId = Guid.NewGuid();
            _customerRepositoryMock.Setup(repo => repo.GetCustomerByIdAsync(nonExistentCustomerId)).ReturnsAsync((Customer)null);

            // Act
            var result = await _customerService.GetCustomerByIdAsync(nonExistentCustomerId);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public async Task GetAllCustomersAsync_ReturnsMappedCustomerDtos()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { CustomerId = Guid.NewGuid(), FirstName = "John", LastName = "Doe" },
                new Customer { CustomerId = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith" }
            };

            _customerRepositoryMock.Setup(repo => repo.GetAllCustomersAsync()).ReturnsAsync(customers);

            // Act
            var result = await _customerService.GetAllCustomersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count); // Adjust based on your actual data
        }

        [Test]
        public async Task AddCustomerAsync_ValidCustomerDto_CallsRepositoryAddAsync()
        {
            // Arrange
            var customerDto = new CustomerDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "123456789",
                Address = "123 Main St",
                Password = "securepassword"
            };

            // Act
            await _customerService.AddCustomerAsync(customerDto);

            // Assert
            _customerRepositoryMock.Verify(repo => repo.AddCustomerAsync(It.IsAny<Customer>()), Times.Once);
        }

        [Test]
        public async Task UpdateCustomerAsync_ValidCustomerDto_CallsRepositoryUpdateAsync()
        {
            // Arrange
            var customerDto = new CustomerDto
            {
                CustomerId = Guid.NewGuid(),
                FirstName = "UpdatedFirstName",
                LastName = "UpdatedLastName",
                Email = "updated.email@example.com",
                Phone = "987654321",
                Address = "456 Updated St",
                Password = "updatedpassword"
            };

            // Act
            await _customerService.UpdateCustomerAsync(customerDto);

            // Assert
            _customerRepositoryMock.Verify(repo => repo.UpdateCustomerAsync(It.IsAny<Customer>()), Times.Once);
        }

        [Test]
        public async Task DeleteCustomerAsync_ValidCustomerId_CallsRepositoryDeleteAsync()
        {
            // Arrange
            var customerId = Guid.NewGuid();

            // Act
            await _customerService.DeleteCustomerAsync(customerId);

            // Assert
            _customerRepositoryMock.Verify(repo => repo.DeleteCustomerAsync(customerId), Times.Once);
        }

        [Test]
        public async Task AddCustomerAsync_WithException_LogsAndRethrowsException()
        {
            // Arrange
            var customerDto = new CustomerDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "123456789",
                Address = "123 Main St",
                Password = "securepassword"
            };

            _customerRepositoryMock.Setup(repo => repo.AddCustomerAsync(It.IsAny<Customer>())).ThrowsAsync(new Exception("Simulated exception"));

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await _customerService.AddCustomerAsync(customerDto));
            // Verify that the exception is logged (add appropriate logging verification)
        }

        // Add more tests as needed
    }
}
