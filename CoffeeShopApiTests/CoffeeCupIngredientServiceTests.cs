using Data.Repository.Interfaces;
using Models;
using Moq;
using NUnit.Framework;

namespace CoffeeShopApiTests;

[TestFixture]
public class CoffeeCupIngredientServiceTests
{
    [Test]
    public async Task GetCoffeeCupIngredientByIdAsync_ShouldReturnCorrectCoffeeCupIngredient()
    {
        var coffeeCupId = Guid.NewGuid();
        var ingredientId = Guid.NewGuid();
        var expectedCoffeeCupIngredient = new CoffeeCupIngredient
            { CoffeeCupId = coffeeCupId, IngredientId = ingredientId };

        var mockCoffeeCupIngredientRepository = new Mock<ICoffeeCupIngredientRepository>();
        mockCoffeeCupIngredientRepository.Setup(repo => repo.GetByIdAsync(coffeeCupId, ingredientId))
            .ReturnsAsync(expectedCoffeeCupIngredient);

        var coffeeCupIngredientService = new CoffeeCupIngredientService(mockCoffeeCupIngredientRepository.Object);

        var result = await coffeeCupIngredientService.GetCoffeeCupIngredientByIdAsync(coffeeCupId, ingredientId);

        Assert.That(expectedCoffeeCupIngredient, Is.EqualTo(result));
    }

    [Test]
    public async Task GetAllCoffeeCupIngredientsAsync_ShouldReturnAllCoffeeCupIngredients()
    {
        var coffeeCupId = Guid.NewGuid();
        var expectedCoffeeCupIngredients = new List<CoffeeCupIngredient>
        {
            new CoffeeCupIngredient { CoffeeCupId = coffeeCupId, IngredientId = Guid.NewGuid() },
            new CoffeeCupIngredient { CoffeeCupId = coffeeCupId, IngredientId = Guid.NewGuid() },
        };

        var mockCoffeeCupIngredientRepository = new Mock<ICoffeeCupIngredientRepository>();
        mockCoffeeCupIngredientRepository.Setup(repo => repo.GetAllAsync(coffeeCupId))
            .ReturnsAsync(expectedCoffeeCupIngredients);

        var coffeeCupIngredientService = new CoffeeCupIngredientService(mockCoffeeCupIngredientRepository.Object);

        var result = await coffeeCupIngredientService.GetAllCoffeeCupIngredientsAsync(coffeeCupId);


        Assert.That(expectedCoffeeCupIngredients, Is.EqualTo(result.ToList()));
    }

    [Test]
    public async Task AddCoffeeCupIngredientAsync_ShouldAddCoffeeCupIngredientToRepository()
    {
        var coffeeCupIngredientToAdd = new CoffeeCupIngredient();

        var mockCoffeeCupIngredientRepository = new Mock<ICoffeeCupIngredientRepository>();
        var coffeeCupIngredientService = new CoffeeCupIngredientService(mockCoffeeCupIngredientRepository.Object);

        await coffeeCupIngredientService.AddCoffeeCupIngredientAsync(coffeeCupIngredientToAdd);

        mockCoffeeCupIngredientRepository.Verify(repo => repo.AddAsync(coffeeCupIngredientToAdd), Times.Once);
    }
}