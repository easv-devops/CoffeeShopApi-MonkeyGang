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
public class OrderDetailServiceTests
{
    private Mock<IOrderDetailRepository> mockOrderDetailRepository;
    private Mock<IMapper> mockMapper;
    private IOrderDetailService orderDetailService;

    [SetUp]
    public void Setup()
    {
        // Arrange
        mockOrderDetailRepository = new Mock<IOrderDetailRepository>();
        mockMapper = new Mock<IMapper>();

        orderDetailService = new OrderDetailService(mockMapper.Object, mockOrderDetailRepository.Object);
    }

    [Test]
    public void GetOrderDetailById_ShouldReturnCorrectOrderDetail()
    {
        // Arrange
        Guid orderDetailId = Guid.NewGuid();
        var orderDetailEntity = new OrderDetail { OrderDetailID = orderDetailId, ItemID = Guid.NewGuid(), ItemType = "Product", Quantity = 2, Subtotal = 15.99m };
        var orderDetailDto = new OrderDetailDto { OrderDetailID = orderDetailId, ItemID = orderDetailEntity.ItemID, ItemType = "Product", Quantity = 2, Subtotal = 15.99m };

        mockOrderDetailRepository.Setup(repo => repo.GetOrderDetailById(orderDetailId)).Returns(orderDetailEntity);
        mockMapper.Setup(mapper => mapper.Map<OrderDetailDto>(orderDetailEntity)).Returns(orderDetailDto);

        // Act
        var result = orderDetailService.GetOrderDetailById(orderDetailId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(orderDetailDto.OrderDetailID, result.OrderDetailID);
        Assert.AreEqual(orderDetailDto.ItemID, result.ItemID);
        Assert.AreEqual(orderDetailDto.ItemType, result.ItemType);
        Assert.AreEqual(orderDetailDto.Quantity, result.Quantity);
        Assert.AreEqual(orderDetailDto.Subtotal, result.Subtotal);
    }

    [Test]
    public void GetAllOrderDetails_ShouldReturnAllOrderDetails()
    {
        // Arrange
        var orderDetailEntities = new List<OrderDetail>
        {
            new OrderDetail { OrderDetailID = Guid.NewGuid(), ItemID = Guid.NewGuid(), ItemType = "Product", Quantity = 2, Subtotal = 15.99m },
            new OrderDetail { OrderDetailID = Guid.NewGuid(), ItemID = Guid.NewGuid(), ItemType = "Product", Quantity = 1, Subtotal = 9.99m }
        };

        var orderDetailDtos = new List<OrderDetailDto>
        {
            new OrderDetailDto { OrderDetailID = orderDetailEntities[0].OrderDetailID, ItemID = orderDetailEntities[0].ItemID, ItemType = "Product", Quantity = 2, Subtotal = 15.99m },
            new OrderDetailDto { OrderDetailID = orderDetailEntities[1].OrderDetailID, ItemID = orderDetailEntities[1].ItemID, ItemType = "Product", Quantity = 1, Subtotal = 9.99m }
        };

        mockOrderDetailRepository.Setup(repo => repo.GetAllOrderDetails()).Returns(orderDetailEntities);
        mockMapper.Setup(mapper => mapper.Map<List<OrderDetailDto>>(orderDetailEntities)).Returns(orderDetailDtos);

        // Act
        var result = orderDetailService.GetAllOrderDetails();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(orderDetailDtos[0].OrderDetailID, result[0].OrderDetailID);
        Assert.AreEqual(orderDetailDtos[1].ItemID, result[1].ItemID);
        Assert.AreEqual(orderDetailDtos[1].Quantity, result[1].Quantity);
        Assert.AreEqual(orderDetailDtos[1].Subtotal, result[1].Subtotal);
    }

    [Test]
    public void AddOrderDetail_ShouldAddOrderDetail()
    {
        // Arrange
        var orderDetailDto = new OrderDetailDto { ItemID = Guid.NewGuid(), ItemType = "Product", Quantity = 3, Subtotal = 29.99m };
        var orderDetailEntity = new OrderDetail { OrderDetailID = Guid.NewGuid(), ItemID = orderDetailDto.ItemID, ItemType = "Product", Quantity = 3, Subtotal = 29.99m };

        mockMapper.Setup(mapper => mapper.Map<OrderDetail>(orderDetailDto)).Returns(orderDetailEntity);

        // Act
        orderDetailService.AddOrderDetail(orderDetailDto);

        // Assert
        mockOrderDetailRepository.Verify(repo => repo.AddOrderDetail(orderDetailEntity), Times.Once);
    }
    
    [Test]
    public void DeleteOrderDetail_ShouldDeleteOrderDetail()
    {
        // Arrange
        Guid orderDetailId = Guid.NewGuid();

        // Act
        orderDetailService.DeleteOrderDetail(orderDetailId);

        // Assert
        mockOrderDetailRepository.Verify(repo => repo.DeleteOrderDetail(orderDetailId), Times.Once);
    }
}