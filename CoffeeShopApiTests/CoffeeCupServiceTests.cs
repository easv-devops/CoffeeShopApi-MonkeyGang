using Data;
using Data.Repository.Interfaces;
using Models;
using Models.DTOs;
using Repository;
using Service;

namespace CoffeeShopApiTests;

using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class CoffeeCupServiceTests
{
    private Mock<ICoffeeCupRepository> mockCoffeeCupRepository;
    private Mock<IItemRepository> mockItemRepository;
    private Mock<IMapper> mockMapper;
    private ICoffeeCupService coffeeCupService;

    [SetUp]
    public void Setup()
    {
        // Arrange
        mockCoffeeCupRepository = new Mock<ICoffeeCupRepository>();
        mockItemRepository = new Mock<IItemRepository>();
        mockMapper = new Mock<IMapper>();

        coffeeCupService = new CoffeeCupService(mockItemRepository.Object, mockCoffeeCupRepository.Object, mockMapper.Object, new CoffeeShopDbContext());
    }

    [Test]
    public void GetCoffeeCupById_ShouldReturnCorrectCoffeeCup()
    {
        // Arrange
        Guid coffeeCupId = Guid.NewGuid();
        var coffeeCupEntity = new CoffeeCup { ItemId = coffeeCupId, Name = "Americano", Price = 3.99m };
        var coffeeCupDto = new CoffeeCupDto { ItemId = coffeeCupId, Name = "Americano", Price = 3.99m };

        mockCoffeeCupRepository.Setup(repo => repo.GetCoffeeCupById(coffeeCupId)).Returns(coffeeCupEntity);
        mockMapper.Setup(mapper => mapper.Map<CoffeeCupDto>(coffeeCupEntity)).Returns(coffeeCupDto);

        // Act
        var result = coffeeCupService.GetCoffeeCupById(coffeeCupId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(coffeeCupDto.ItemId, result.ItemId);
        Assert.AreEqual(coffeeCupDto.Name, result.Name);
        Assert.AreEqual(coffeeCupDto.Price, result.Price);
    }

    [Test]
    public void GetAllCoffeeCups_ShouldReturnAllCoffeeCups()
    {
        // Arrange
        var coffeeCupEntities = new List<CoffeeCup>
        {
            new CoffeeCup { ItemId = Guid.NewGuid(), Name = "Latte", Price = 4.99m },
            new CoffeeCup { ItemId = Guid.NewGuid(), Name = "Cappuccino", Price = 5.99m }
        };

        var coffeeCupDtos = new List<CoffeeCupDto>
        {
            new CoffeeCupDto { ItemId = coffeeCupEntities[0].ItemId, Name = "Latte", Price = 4.99m },
            new CoffeeCupDto { ItemId = coffeeCupEntities[1].ItemId, Name = "Cappuccino", Price = 5.99m }
        };

        mockCoffeeCupRepository.Setup(repo => repo.GetAllCoffeeCups()).Returns(coffeeCupEntities);
        mockMapper.Setup(mapper => mapper.Map<List<CoffeeCupDto>>(coffeeCupEntities)).Returns(coffeeCupDtos);

        // Act
        var result = coffeeCupService.GetAllCoffeeCups();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(coffeeCupDtos[0].ItemId, result[0].ItemId);
        Assert.AreEqual(coffeeCupDtos[1].Name, result[1].Name);
        Assert.AreEqual(coffeeCupDtos[1].Price, result[1].Price);
    }

    // Add tests for AddCoffeeCup, UpdateCoffeeCup, and DeleteCoffeeCup methods as needed
}