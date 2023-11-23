using AutoMapper;
using Data.Repository;
using Models;
using Presentation.DTOs;
using Service;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;

[TestFixture]
public class OrderServiceTests
{
    private Mock<IOrderRepository> mockOrderRepository;
    private Mock<IMapper> mockMapper;
    private IOrderService orderService;

    [SetUp]
    public void Setup()
    {
        // Arrange
        mockOrderRepository = new Mock<IOrderRepository>();
        mockMapper = new Mock<IMapper>();

        orderService = new OrderService(mockMapper.Object, mockOrderRepository.Object);
    }

    [Test]
    public void GetOrderById_ShouldReturnCorrectOrder()
    {
        // Arrange
        Guid orderId = Guid.NewGuid();
        var orderEntity = new Order { OrderID = orderId, CustomerID = Guid.NewGuid(), OrderDate = DateTime.Now, TotalAmount = 45.99m };
        var orderDto = new OrderDto { OrderID = orderId, CustomerID = orderEntity.CustomerID, OrderDate = orderEntity.OrderDate, TotalAmount = 45.99m };

        mockOrderRepository.Setup(repo => repo.GetOrderById(orderId)).Returns(orderEntity);
        mockMapper.Setup(mapper => mapper.Map<OrderDto>(orderEntity)).Returns(orderDto);

        // Act
        var result = orderService.GetOrderById(orderId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(orderDto.OrderID, result.OrderID);
        Assert.AreEqual(orderDto.CustomerID, result.CustomerID);
        Assert.AreEqual(orderDto.OrderDate, result.OrderDate);
        Assert.AreEqual(orderDto.TotalAmount, result.TotalAmount);
    }

    [Test]
    public void GetAllOrders_ShouldReturnAllOrders()
    {
        // Arrange
        var orderEntities = new List<Order>
        {
            new Order { OrderID = Guid.NewGuid(), CustomerID = Guid.NewGuid(), OrderDate = DateTime.Now, TotalAmount = 35.99m },
            new Order { OrderID = Guid.NewGuid(), CustomerID = Guid.NewGuid(), OrderDate = DateTime.Now, TotalAmount = 25.99m }
        };

        var orderDtos = new List<OrderDto>
        {
            new OrderDto { OrderID = orderEntities[0].OrderID, CustomerID = orderEntities[0].CustomerID, OrderDate = orderEntities[0].OrderDate, TotalAmount = 35.99m },
            new OrderDto { OrderID = orderEntities[1].OrderID, CustomerID = orderEntities[1].CustomerID, OrderDate = orderEntities[1].OrderDate, TotalAmount = 25.99m }
        };

        mockOrderRepository.Setup(repo => repo.GetAllOrders()).Returns(orderEntities);
        mockMapper.Setup(mapper => mapper.Map<List<OrderDto>>(orderEntities)).Returns(orderDtos);

        // Act
        var result = orderService.GetAllOrders();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(orderDtos[0].OrderID, result[0].OrderID);
        Assert.AreEqual(orderDtos[1].CustomerID, result[1].CustomerID);
        Assert.AreEqual(orderDtos[1].TotalAmount, result[1].TotalAmount);
    }

    [Test]
    public void AddOrder_ShouldAddOrder()
    {
        // Arrange
        var orderDto = new OrderDto { CustomerID = Guid.NewGuid(), OrderDate = DateTime.Now, TotalAmount = 19.99m };
        var orderEntity = new Order { OrderID = Guid.NewGuid(), CustomerID = orderDto.CustomerID, OrderDate = orderDto.OrderDate, TotalAmount = 19.99m };

        mockMapper.Setup(mapper => mapper.Map<Order>(orderDto)).Returns(orderEntity);

        // Act
        orderService.AddOrder(orderDto);

        // Assert
        mockOrderRepository.Verify(repo => repo.AddOrder(orderEntity), Times.Once);
    }

    [Test]
    public void UpdateOrder_ShouldUpdateOrder()
    {
        // Arrange
        Guid orderId = Guid.NewGuid();
        var orderDto = new OrderDto { OrderID = orderId, CustomerID = Guid.NewGuid(), OrderDate = DateTime.Now, TotalAmount = 29.99m };
        var orderEntity = new Order { OrderID = orderId, CustomerID = orderDto.CustomerID, OrderDate = orderDto.OrderDate, TotalAmount = 29.99m };

        mockMapper.Setup(mapper => mapper.Map<Order>(orderDto)).Returns(orderEntity);

        // Act
        orderService.UpdateOrder(orderDto);

        // Assert
        mockOrderRepository.Verify(repo => repo.UpdateOrder(orderEntity), Times.Once);
    }

    [Test]
    public void DeleteOrder_ShouldDeleteOrder()
    {
        // Arrange
        Guid orderId = Guid.NewGuid();

        // Act
        orderService.DeleteOrder(orderId);

        // Assert
        mockOrderRepository.Verify(repo => repo.DeleteOrder(orderId), Times.Once);
    }
}
