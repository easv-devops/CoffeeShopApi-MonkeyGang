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
        mockCoffeeCupIngredientRepository = new Mock<ICoffeeCupIngredientRepository>();
        coffeeCupIngredientService = new CoffeeCupIngredientService(mockCoffeeCupIngredientRepository.Object);
    }

    [Test]
    public void GetCoffeeCupIngredient_ShouldReturnCorrectCoffeeCupIngredient()
    {
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

        var result = coffeeCupIngredientService.GetCoffeeCupIngredient(coffeeCupId, ingredientId);

        Assert.IsNotNull(result);
        Assert.AreEqual(expectedCoffeeCupIngredient, result);
    }

    [Test]
    public void GetCoffeeCupIngredients_ShouldReturnCorrectCoffeeCupIngredients()
    {
        Guid coffeeCupId = Guid.NewGuid();

        var expectedCoffeeCupIngredients = new List<CoffeeCupIngredient>
        {
            new CoffeeCupIngredient { CoffeeCupId = coffeeCupId, IngredientId = Guid.NewGuid(), Quantity = 1 },
            new CoffeeCupIngredient { CoffeeCupId = coffeeCupId, IngredientId = Guid.NewGuid(), Quantity = 3 }
        };

        mockCoffeeCupIngredientRepository.Setup(repo =>
            repo.GetCoffeeCupIngredients(coffeeCupId)).Returns(expectedCoffeeCupIngredients);

        var result = coffeeCupIngredientService.GetCoffeeCupIngredients(coffeeCupId);

        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(expectedCoffeeCupIngredients, result);
    }

    [Test]
    public void AddCoffeeCupIngredient_ShouldAddCoffeeCupIngredient()
    {
        var coffeeCupIngredientToAdd = new CoffeeCupIngredient
        {
            CoffeeCupId = Guid.NewGuid(),
            IngredientId = Guid.NewGuid(),
            Quantity = 2
        };

        coffeeCupIngredientService.AddCoffeeCupIngredient(coffeeCupIngredientToAdd);

        mockCoffeeCupIngredientRepository.Verify(repo => repo.AddCoffeeCupIngredient(coffeeCupIngredientToAdd),
            Times.Once);
    }

    [Test]
    public void UpdateCoffeeCupIngredient_ShouldUpdateCoffeeCupIngredient()
    {
        var coffeeCupIngredientToUpdate = new CoffeeCupIngredient
        {
            CoffeeCupId = Guid.NewGuid(),
            IngredientId = Guid.NewGuid(),
            Quantity = 3
        };

        coffeeCupIngredientService.UpdateCoffeeCupIngredient(coffeeCupIngredientToUpdate);

        mockCoffeeCupIngredientRepository.Verify(repo => repo.UpdateCoffeeCupIngredient(coffeeCupIngredientToUpdate),
            Times.Once);
    }

    [Test]
    public void DeleteCoffeeCupIngredient_ShouldDeleteCoffeeCupIngredient()
    {
        Guid coffeeCupId = Guid.NewGuid();
        Guid ingredientId = Guid.NewGuid();

        coffeeCupIngredientService.DeleteCoffeeCupIngredient(coffeeCupId, ingredientId);

        mockCoffeeCupIngredientRepository.Verify(repo => repo.DeleteCoffeeCupIngredient(coffeeCupId, ingredientId),
            Times.Once);
    }
}