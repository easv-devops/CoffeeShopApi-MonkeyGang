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
        var orderDetailEntity = new OrderDetail
            { OrderDetailId = orderDetailId, ItemId = Guid.NewGuid(), Quantity = 2, Subtotal = 15.99m };
        var orderDetailDto = new OrderDetailDto
            { OrderDetailId = orderDetailId, ItemId = orderDetailEntity.ItemId, Quantity = 2, Subtotal = 15.99m };

        mockOrderDetailRepository.Setup(repo => repo.GetOrderDetailById(orderDetailId)).Returns(orderDetailEntity);
        mockMapper.Setup(mapper => mapper.Map<OrderDetailDto>(orderDetailEntity)).Returns(orderDetailDto);

        // Act
        var result = orderDetailService.GetOrderDetailById(orderDetailId);

        // Assert
        Assert.That(result, Is.Not.Null);     
        Assert.That(orderDetailDto.ItemId,Is.EqualTo( result.ItemId));
        Assert.That(orderDetailDto.Quantity,Is.EqualTo( result.Quantity));
        Assert.That(orderDetailDto.Subtotal,Is.EqualTo( result.Subtotal));
    }

    [Test]
    public void GetAllOrderDetails_ShouldReturnAllOrderDetails()
    {
        // Arrange
        var orderDetailEntities = new List<OrderDetail>
        {
            new OrderDetail
                { OrderDetailId = Guid.NewGuid(), ItemId = Guid.NewGuid(), Quantity = 2, Subtotal = 15.99m },
            new OrderDetail { OrderDetailId = Guid.NewGuid(), ItemId = Guid.NewGuid(), Quantity = 1, Subtotal = 9.99m }
        };

        var orderDetailDtos = new List<OrderDetailDto>
        {
            new OrderDetailDto
            {
                OrderDetailId = orderDetailEntities[0].OrderDetailId, ItemId = orderDetailEntities[0].ItemId,
                Quantity = 2, Subtotal = 15.99m
            },
            new OrderDetailDto
            {
                OrderDetailId = orderDetailEntities[1].OrderDetailId, ItemId = orderDetailEntities[1].ItemId,
                Quantity = 1, Subtotal = 9.99m
            }
        };

        mockOrderDetailRepository.Setup(repo => repo.GetAllOrderDetails()).Returns(orderDetailEntities);
        mockMapper.Setup(mapper => mapper.Map<List<OrderDetailDto>>(orderDetailEntities)).Returns(orderDetailDtos);

        var result = orderDetailService.GetAllOrderDetails();

        Assert.That(result, Is.Not.Null);
        Assert.That(2, Is.EqualTo(result.Count));
        Assert.That(orderDetailDtos[0].OrderDetailId,Is.EqualTo( result[0].OrderDetailId));
        Assert.That(orderDetailDtos[1].ItemId,Is.EqualTo( result[1].ItemId));
        Assert.That(orderDetailDtos[1].Quantity,Is.EqualTo( result[1].Quantity));
        Assert.That(orderDetailDtos[1].Subtotal,Is.EqualTo( result[1].Subtotal));
    }

    [Test]
    public void AddOrderDetail_ShouldAddOrderDetail()
    {
        var orderDetailDto = new OrderDetailDto { ItemId = Guid.NewGuid(), Quantity = 3, Subtotal = 29.99m };
        var orderDetailEntity = new OrderDetail
            { OrderDetailId = Guid.NewGuid(), ItemId = orderDetailDto.ItemId, Quantity = 3, Subtotal = 29.99m };

        mockMapper.Setup(mapper => mapper.Map<OrderDetail>(orderDetailDto)).Returns(orderDetailEntity);

        orderDetailService.AddOrderDetail(orderDetailDto);

        mockOrderDetailRepository.Verify(repo => repo.AddOrderDetail(orderDetailEntity), Times.Once);
    }

    [Test]
    public void DeleteOrderDetail_ShouldDeleteOrderDetail()
    {
        Guid orderDetailId = Guid.NewGuid();

        orderDetailService.DeleteOrderDetail(orderDetailId);

        mockOrderDetailRepository.Verify(repo => repo.DeleteOrderDetail(orderDetailId), Times.Once);
    }
}