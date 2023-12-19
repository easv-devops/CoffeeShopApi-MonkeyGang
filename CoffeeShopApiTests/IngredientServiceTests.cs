using AutoMapper;
using Business.Service;
using Data.Repository;
using Models;
using Models.DTOs;
using Moq;
using NUnit.Framework;
using Presentation;
using Service;

namespace CoffeeShopApiTests;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[TestFixture]
public class IngredientServiceTests
{
    private Mock<IIngredientRepository> _ingredientRepositoryMock;
    private IMapper _mapper;
    private IIngredientService _ingredientService;

    [SetUp]
    public void SetUp()
    {
        _ingredientRepositoryMock = new Mock<IIngredientRepository>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        _ingredientService = new IngredientService(_ingredientRepositoryMock.Object, _mapper);
    }

    [Test]
    public async Task GetAllIngredientsAsync_ShouldReturnListOfIngredients()
    {
        var ingredientsFromRepository = new List<Ingredient>
        {
            new Ingredient { IngredientId = Guid.NewGuid(), Name = "Ingredient1" },
            new Ingredient { IngredientId = Guid.NewGuid(), Name = "Ingredient2" },
        };

        _ingredientRepositoryMock.Setup(repo => repo.GetAllIngredientsAsync())
            .ReturnsAsync(ingredientsFromRepository);

        var result = await _ingredientService.GetAllIngredientsAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(ingredientsFromRepository.Count, Is.EqualTo(result.Count));
    }

    [Test]
    public async Task GetIngredientByIdAsync_WithValidId_ShouldReturnIngredientDto()
    {
        var existingIngredientId = Guid.NewGuid();
        var existingIngredient = new Ingredient { IngredientId = existingIngredientId, Name = "ExistingIngredient" };

        _ingredientRepositoryMock.Setup(repo => repo.GetIngredientByIdAsync(existingIngredientId))
            .ReturnsAsync(existingIngredient);

        var result = await _ingredientService.GetIngredientByIdAsync(existingIngredientId);

        Assert.That(result, Is.Not.Null);
        Assert.That(existingIngredientId, Is.EqualTo(result.IngredientId));
    }

    [Test]
    public async Task AddIngredientAsync_ShouldReturnNewIngredientId()
    {
        var newIngredientDto = new IngredientDto
        {
            Name = "NewIngredient",
            Price = 10.99m,
        };

        var newIngredientId = Guid.NewGuid();
        var newIngredient = new Ingredient { IngredientId = newIngredientId, Name = "NewIngredient" };

        _ingredientRepositoryMock.Setup(repo => repo.AddIngredientAsync(It.IsAny<Ingredient>()))
            .ReturnsAsync(newIngredientId);


        var result = await _ingredientService.AddIngredientAsync(newIngredientDto);

        Assert.That(newIngredientId, Is.EqualTo(result));
    }

    [Test]
    public async Task UpdateIngredientAsync_WithValidId_ShouldReturnTrue()
    {
        var existingIngredientId = Guid.NewGuid();
        var existingIngredientDto = new IngredientDto
            { IngredientId = existingIngredientId, Name = "ExistingIngredient" };
        var existingIngredient = new Ingredient { IngredientId = existingIngredientId, Name = "ExistingIngredient" };

        _ingredientRepositoryMock.Setup(repo => repo.GetIngredientByIdAsync(existingIngredientId))
            .ReturnsAsync(existingIngredient);


        _ingredientRepositoryMock.Setup(repo => repo.UpdateIngredientAsync(existingIngredient))
            .ReturnsAsync(true);

        var result = await _ingredientService.UpdateIngredientAsync(existingIngredientId, existingIngredientDto);


        Assert.That(result, Is.True);
    }

    [Test]
    public async Task DeleteIngredientAsync_WithValidId_ShouldReturnTrue()
    {
        var existingIngredientId = Guid.NewGuid();
        var existingIngredient = new Ingredient { IngredientId = existingIngredientId, Name = "ExistingIngredient" };

        _ingredientRepositoryMock.Setup(repo => repo.GetIngredientByIdAsync(existingIngredientId))
            .ReturnsAsync(existingIngredient);

        _ingredientRepositoryMock.Setup(repo => repo.DeleteIngredientAsync(existingIngredient))
            .ReturnsAsync(true);

        var result = await _ingredientService.DeleteIngredientAsync(existingIngredientId);

        Assert.That(result, Is.True);
    }
}