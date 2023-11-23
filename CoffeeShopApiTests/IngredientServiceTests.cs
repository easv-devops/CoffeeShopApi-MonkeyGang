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
public class IngredientServiceTests
{
    private Mock<IIngredientRepository> mockIngredientRepository;
    private Mock<IMapper> mockMapper;
    private IIngredientService ingredientService;

    [SetUp]
    public void Setup()
    {
        // Arrange
        mockIngredientRepository = new Mock<IIngredientRepository>();
        mockMapper = new Mock<IMapper>();

        ingredientService = new IngredientService(mockMapper.Object, mockIngredientRepository.Object);
    }

    [Test]
    public void GetIngredientById_ShouldReturnCorrectIngredient()
    {
        // Arrange
        Guid ingredientId = Guid.NewGuid();
        var ingredientEntity = new Ingredient { IngredientID = ingredientId, Name = "Sugar", QuantityInStock = 100 };
        var ingredientDto = new IngredientDto { IngredientID = ingredientId, Name = "Sugar", QuantityInStock = 100 };

        mockIngredientRepository.Setup(repo => repo.GetIngredientById(ingredientId)).Returns(ingredientEntity);
        mockMapper.Setup(mapper => mapper.Map<IngredientDto>(ingredientEntity)).Returns(ingredientDto);

        // Act
        var result = ingredientService.GetIngredientById(ingredientId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(ingredientDto.IngredientID, result.IngredientID);
        Assert.AreEqual(ingredientDto.Name, result.Name);
        Assert.AreEqual(ingredientDto.QuantityInStock, result.QuantityInStock);
    }

    [Test]
    public void GetAllIngredients_ShouldReturnAllIngredients()
    {
        // Arrange
        var ingredientEntities = new List<Ingredient>
        {
            new Ingredient { IngredientID = Guid.NewGuid(), Name = "Coffee Beans", QuantityInStock = 200 },
            new Ingredient { IngredientID = Guid.NewGuid(), Name = "Milk", QuantityInStock = 50 }
        };

        var ingredientDtos = new List<IngredientDto>
        {
            new IngredientDto { IngredientID = ingredientEntities[0].IngredientID, Name = "Coffee Beans", QuantityInStock = 200 },
            new IngredientDto { IngredientID = ingredientEntities[1].IngredientID, Name = "Milk", QuantityInStock = 50 }
        };

        mockIngredientRepository.Setup(repo => repo.GetAllIngredients()).Returns(ingredientEntities);
        mockMapper.Setup(mapper => mapper.Map<List<IngredientDto>>(ingredientEntities)).Returns(ingredientDtos);

        // Act
        var result = ingredientService.GetAllIngredients();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(ingredientDtos[0].IngredientID, result[0].IngredientID);
        Assert.AreEqual(ingredientDtos[1].Name, result[1].Name);
        Assert.AreEqual(ingredientDtos[1].QuantityInStock, result[1].QuantityInStock);
    }

    [Test]
    public void AddIngredient_ShouldAddIngredient()
    {
        // Arrange
        var ingredientDto = new IngredientDto { Name = "New Ingredient", QuantityInStock = 75 };
        var ingredientEntity = new Ingredient { IngredientID = Guid.NewGuid(), Name = "New Ingredient", QuantityInStock = 75 };

        mockMapper.Setup(mapper => mapper.Map<Ingredient>(ingredientDto)).Returns(ingredientEntity);

        // Act
        ingredientService.AddIngredient(ingredientDto);

        // Assert
        mockIngredientRepository.Verify(repo => repo.AddIngredient(ingredientEntity), Times.Once);
    }

    [Test]
    public void UpdateIngredient_ShouldUpdateIngredient()
    {
        // Arrange
        Guid ingredientId = Guid.NewGuid();
        var ingredientDto = new IngredientDto { IngredientID = ingredientId, Name = "Updated Ingredient", QuantityInStock = 120 };
        var ingredientEntity = new Ingredient { IngredientID = ingredientId, Name = "Updated Ingredient", QuantityInStock = 120 };

        mockMapper.Setup(mapper => mapper.Map<Ingredient>(ingredientDto)).Returns(ingredientEntity);

        // Act
        ingredientService.UpdateIngredient(ingredientDto);

        // Assert
        mockIngredientRepository.Verify(repo => repo.UpdateIngredient(ingredientEntity), Times.Once);
    }

    [Test]
    public void DeleteIngredient_ShouldDeleteIngredient()
    {
        // Arrange
        Guid ingredientId = Guid.NewGuid();

        // Act
        ingredientService.DeleteIngredient(ingredientId);

        // Assert
        mockIngredientRepository.Verify(repo => repo.DeleteIngredient(ingredientId), Times.Once);
    }
}
