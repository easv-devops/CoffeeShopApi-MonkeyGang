using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Service;
using Data.Repository;
using Data.Repository.Interfaces;
using Models;

namespace CoffeeShopApiTests;

[TestFixture]
public class CoffeeCupIngredientServiceTests
{
    private Mock<ICoffeeCupIngredientRepository> mockCoffeeCupIngredientRepository;
    private ICoffeeCupIngredientService coffeeCupIngredientService;

    [SetUp]
    public void Setup()
    {
        // Arrange
        mockCoffeeCupIngredientRepository = new Mock<ICoffeeCupIngredientRepository>();
        coffeeCupIngredientService = new CoffeeCupIngredientService(mockCoffeeCupIngredientRepository.Object);
    }

    [Test]
    public void GetCoffeeCupIngredient_ShouldReturnCorrectCoffeeCupIngredient()
    {
        // Arrange
        Guid coffeeCupId = Guid.NewGuid();
        Guid ingredientId = Guid.NewGuid();

        var expectedCoffeeCupIngredient = new CoffeeCupIngredient
        {
            CoffeeCupId = coffeeCupId,
            IngredientId = ingredientId,
            Quantity = 2 // Example value
        };

        mockCoffeeCupIngredientRepository.Setup(repo =>
            repo.GetCoffeeCupIngredient(coffeeCupId, ingredientId)).Returns(expectedCoffeeCupIngredient);

        // Act
        var result = coffeeCupIngredientService.GetCoffeeCupIngredient(coffeeCupId, ingredientId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedCoffeeCupIngredient, result);
    }

    [Test]
    public void GetCoffeeCupIngredients_ShouldReturnCorrectCoffeeCupIngredients()
    {
        // Arrange
        Guid coffeeCupId = Guid.NewGuid();

        var expectedCoffeeCupIngredients = new List<CoffeeCupIngredient>
        {
            new CoffeeCupIngredient { CoffeeCupId = coffeeCupId, IngredientId = Guid.NewGuid(), Quantity = 1 },
            new CoffeeCupIngredient { CoffeeCupId = coffeeCupId, IngredientId = Guid.NewGuid(), Quantity = 3 }
        };

        mockCoffeeCupIngredientRepository.Setup(repo =>
            repo.GetCoffeeCupIngredients(coffeeCupId)).Returns(expectedCoffeeCupIngredients);

        // Act
        var result = coffeeCupIngredientService.GetCoffeeCupIngredients(coffeeCupId);

        // Assert
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(expectedCoffeeCupIngredients, result);
    }

    [Test]
    public void AddCoffeeCupIngredient_ShouldAddCoffeeCupIngredient()
    {
        // Arrange
        var coffeeCupIngredientToAdd = new CoffeeCupIngredient
        {
            CoffeeCupId = Guid.NewGuid(),
            IngredientId = Guid.NewGuid(),
            Quantity = 2
        };

        // Act
        coffeeCupIngredientService.AddCoffeeCupIngredient(coffeeCupIngredientToAdd);

        // Assert
        mockCoffeeCupIngredientRepository.Verify(repo => repo.AddCoffeeCupIngredient(coffeeCupIngredientToAdd),
            Times.Once);
    }

    [Test]
    public void UpdateCoffeeCupIngredient_ShouldUpdateCoffeeCupIngredient()
    {
        // Arrange
        var coffeeCupIngredientToUpdate = new CoffeeCupIngredient
        {
            CoffeeCupId = Guid.NewGuid(),
            IngredientId = Guid.NewGuid(),
            Quantity = 3
        };

        // Act
        coffeeCupIngredientService.UpdateCoffeeCupIngredient(coffeeCupIngredientToUpdate);

        // Assert
        mockCoffeeCupIngredientRepository.Verify(repo => repo.UpdateCoffeeCupIngredient(coffeeCupIngredientToUpdate),
            Times.Once);
    }

    [Test]
    public void DeleteCoffeeCupIngredient_ShouldDeleteCoffeeCupIngredient()
    {
        // Arrange
        Guid coffeeCupId = Guid.NewGuid();
        Guid ingredientId = Guid.NewGuid();

        // Act
        coffeeCupIngredientService.DeleteCoffeeCupIngredient(coffeeCupId, ingredientId);

        // Assert
        mockCoffeeCupIngredientRepository.Verify(repo => repo.DeleteCoffeeCupIngredient(coffeeCupId, ingredientId),
            Times.Once);
    }
}