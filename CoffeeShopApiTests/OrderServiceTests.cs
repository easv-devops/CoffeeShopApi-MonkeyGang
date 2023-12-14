using AutoMapper;
using Data.Repository;
using Models;
using Models.DTOs;
using Service;
using NUnit.Framework;
using Moq;

namespace CoffeeShopApiTests;

using System;
using System.Collections.Generic;

[TestFixture]
public class OrderServiceTests
{
    private Mock<IOrderRepository> _orderRepositoryMock;
    private OrderService _orderService;

    [SetUp]
    public void Setup()
    {
        _orderRepositoryMock = new Mock<IOrderRepository>();
        _orderService = new OrderService(_orderRepositoryMock.Object);
    }

    [Test]
    public async Task GetAllOrdersAsync_ShouldReturnAllOrders()
    {
        // Arrange
        var orders = new List<Order> { /* create your sample orders */ };
        _orderRepositoryMock.Setup(repo => repo.GetAllOrdersAsync()).ReturnsAsync(orders);

        // Act
        var result = await _orderService.GetAllOrdersAsync();

        // Assert
        Assert.That(result, Is.Not.Null);
        
        Assert.That(orders.Count,Is.EqualTo( result.Count));
    }

    [Test]
    public async Task GetOrderByIdAsync_WithValidId_ShouldReturnOrder()
    {
        // Arrange
        var orderId = Guid.NewGuid();
        var order = new Order { OrderId = orderId, /* other properties */ };
        _orderRepositoryMock.Setup(repo => repo.GetOrderByIdAsync(orderId)).ReturnsAsync(order);

        // Act
        var result = await _orderService.GetOrderByIdAsync(orderId);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(orderId, Is.EqualTo(result.OrderId));
    }

    [Test]
    public async Task GetOrderByIdAsync_WithInvalidId_ShouldReturnNull()
    {
        // Arrange
        var invalidOrderId = Guid.NewGuid();
        _orderRepositoryMock.Setup(repo => repo.GetOrderByIdAsync(invalidOrderId)).ReturnsAsync(null as Order);

        // Act
        var result = await _orderService.GetOrderByIdAsync(invalidOrderId);

        // Assert
        Assert.That(result, Is.Null);
        
    }

    [Test]
    public async Task AddOrderAsync_ShouldAddOrder()
    {
        // Arrange
        var newOrder = new Order { /* set properties for the new order */ };
        _orderRepositoryMock.Setup(repo => repo.AddOrderAsync(newOrder)).Returns(Task.CompletedTask);

        // Act
        await _orderService.AddOrderAsync(newOrder);

        // Assert
        _orderRepositoryMock.Verify(repo => repo.AddOrderAsync(newOrder), Times.Once);
    }

    [Test]
    public async Task UpdateOrderAsync_WithValidOrder_ShouldUpdateOrder()
    {
        // Arrange
        var existingOrder = new Order { OrderId = Guid.NewGuid(), /* other properties */ };
        var updatedOrder = new Order { OrderId = existingOrder.OrderId, /* updated properties */ };

        _orderRepositoryMock.Setup(repo => repo.GetOrderByIdAsync(existingOrder.OrderId)).ReturnsAsync(existingOrder);
        _orderRepositoryMock.Setup(repo => repo.UpdateOrderAsync(updatedOrder)).Returns(Task.CompletedTask);

        // Act
        await _orderService.UpdateOrderAsync(updatedOrder);

        // Assert
        _orderRepositoryMock.Verify(repo => repo.UpdateOrderAsync(updatedOrder), Times.Once);
    }

    [Test]
    public async Task UpdateOrderAsync_WithInvalidOrder_ShouldThrowArgumentException()
    {
        // Arrange
        var invalidOrder = new Order(); // Create an invalid order, e.g., with an empty OrderId

        var orderRepositoryMock = new Mock<IOrderRepository>();
        var orderService = new OrderService(orderRepositoryMock.Object);

        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(async () => await orderService.UpdateOrderAsync(invalidOrder));
        orderRepositoryMock.Verify(repo => repo.UpdateOrderAsync(It.IsAny<Order>()), Times.Never);
    }

    [Test]
    public async Task DeleteOrderAsync_WithValidId_ShouldDeleteOrder()
    {
        // Arrange
        var orderIdToDelete = Guid.NewGuid();
        var existingOrder = new Order { OrderId = orderIdToDelete, /* other properties */ };

        _orderRepositoryMock.Setup(repo => repo.GetOrderByIdAsync(orderIdToDelete)).ReturnsAsync(existingOrder);
        _orderRepositoryMock.Setup(repo => repo.DeleteOrderAsync(orderIdToDelete)).Returns(Task.CompletedTask);

        // Act
        await _orderService.DeleteOrderAsync(orderIdToDelete);

        // Assert
        _orderRepositoryMock.Verify(repo => repo.DeleteOrderAsync(orderIdToDelete), Times.Once);
    }

    [Test]
    public async Task DeleteOrderAsync_WithInvalidId_ShouldNotDeleteOrder()
    {
        // Arrange
        var invalidOrderId = Guid.NewGuid();

        _orderRepositoryMock.Setup(repo => repo.GetOrderByIdAsync(invalidOrderId)).ReturnsAsync((Order?)null);
        // Assert
        _orderRepositoryMock.Verify(repo => repo.DeleteOrderAsync(It.IsAny<Guid>()), Times.Never);
        _orderRepositoryMock.Verify(repo => repo.DeleteOrderAsync(invalidOrderId), Times.Never);
    }
}