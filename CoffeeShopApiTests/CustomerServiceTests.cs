using AutoMapper;
using Data.Repository;
using Models;
using Presentation.DTOs;
using Service;

namespace CoffeeShopApiTests;

using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;

[TestFixture]
public class CustomerServiceTests
{
    private Mock<ICustomerRepository> mockCustomerRepository;
    private Mock<IMapper> mockMapper;
    private ICustomerService customerService;

    [SetUp]
    public void Setup()
    {
        // Arrange
        mockCustomerRepository = new Mock<ICustomerRepository>();
        mockMapper = new Mock<IMapper>();

        customerService = new CustomerService(mockMapper.Object, mockCustomerRepository.Object);
    }

    [Test]
    public void GetCustomerById_ShouldReturnCorrectCustomer()
    {
        // Arrange
        Guid customerId = Guid.NewGuid();
        var customerEntity = new Customer
            { CustomerID = customerId, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" };
        var customerDto = new CustomerDto
            { CustomerID = customerId, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" };

        mockCustomerRepository.Setup(repo => repo.GetCustomerById(customerId)).Returns(customerEntity);
        mockMapper.Setup(mapper => mapper.Map<CustomerDto>(customerEntity)).Returns(customerDto);

        // Act
        var result = customerService.GetCustomerById(customerId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(customerDto.CustomerID, result.CustomerID);
        Assert.AreEqual(customerDto.FirstName, result.FirstName);
        Assert.AreEqual(customerDto.LastName, result.LastName);
        Assert.AreEqual(customerDto.Email, result.Email);
    }

    [Test]
    public void GetAllCustomers_ShouldReturnAllCustomers()
    {
        // Arrange
        var customerEntities = new List<Customer>
        {
            new Customer
            {
                CustomerID = Guid.NewGuid(), FirstName = "Alice", LastName = "Smith", Email = "alice.smith@example.com"
            },
            new Customer
            {
                CustomerID = Guid.NewGuid(), FirstName = "Bob", LastName = "Johnson", Email = "bob.johnson@example.com"
            }
        };

        var customerDtos = new List<CustomerDto>
        {
            new CustomerDto
            {
                CustomerID = customerEntities[0].CustomerID, FirstName = "Alice", LastName = "Smith",
                Email = "alice.smith@example.com"
            },
            new CustomerDto
            {
                CustomerID = customerEntities[1].CustomerID, FirstName = "Bob", LastName = "Johnson",
                Email = "bob.johnson@example.com"
            }
        };

        mockCustomerRepository.Setup(repo => repo.GetAllCustomers()).Returns(customerEntities);
        mockMapper.Setup(mapper => mapper.Map<List<CustomerDto>>(customerEntities)).Returns(customerDtos);

        // Act
        var result = customerService.GetAllCustomers();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(customerDtos[0].CustomerID, result[0].CustomerID);
        Assert.AreEqual(customerDtos[1].FirstName, result[1].FirstName);
        Assert.AreEqual(customerDtos[1].Email, result[1].Email);
    }

    [Test]
    public void AddCustomer_ShouldAddCustomer()
    {
        // Arrange
        var customerDto = new CustomerDto
            { FirstName = "New", LastName = "Customer", Email = "new.customer@example.com" };
        var customerEntity = new Customer
        {
            CustomerID = Guid.NewGuid(), FirstName = "New", LastName = "Customer", Email = "new.customer@example.com"
        };

        mockMapper.Setup(mapper => mapper.Map<Customer>(customerDto)).Returns(customerEntity);

        // Act
        customerService.AddCustomer(customerDto);

        // Assert
        mockCustomerRepository.Verify(repo => repo.AddCustomer(customerEntity), Times.Once);
    }

    [Test]
    public void UpdateCustomer_ShouldUpdateCustomer()
    {
        // Arrange
        Guid customerId = Guid.NewGuid();
        var customerDto = new CustomerDto
        {
            CustomerID = customerId, FirstName = "Updated", LastName = "Customer",
            Email = "updated.customer@example.com"
        };
        var customerEntity = new Customer
        {
            CustomerID = customerId, FirstName = "Updated", LastName = "Customer",
            Email = "updated.customer@example.com"
        };

        mockMapper.Setup(mapper => mapper.Map<Customer>(customerDto)).Returns(customerEntity);

        // Act
        customerService.UpdateCustomer(customerDto);

        // Assert
        mockCustomerRepository.Verify(repo => repo.UpdateCustomer(customerEntity), Times.Once);
    }

    [Test]
    public void DeleteCustomer_ShouldDeleteCustomer()
    {
        // Arrange
        Guid customerId = Guid.NewGuid();

        // Act
        customerService.DeleteCustomer(customerId);

        // Assert
        mockCustomerRepository.Verify(repo => repo.DeleteCustomer(customerId), Times.Once);
    }
}