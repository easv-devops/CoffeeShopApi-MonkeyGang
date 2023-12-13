
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
        // Arrange
        var coffeeCupId = Guid.NewGuid();
        var ingredientId = Guid.NewGuid();
        var expectedCoffeeCupIngredient = new CoffeeCupIngredient { CoffeeCupId = coffeeCupId, IngredientId = ingredientId };

        var mockCoffeeCupIngredientRepository = new Mock<ICoffeeCupIngredientRepository>();
        mockCoffeeCupIngredientRepository.Setup(repo => repo.GetByIdAsync(coffeeCupId, ingredientId)).ReturnsAsync(expectedCoffeeCupIngredient);

        var coffeeCupIngredientService = new CoffeeCupIngredientService(mockCoffeeCupIngredientRepository.Object);

        // Act
        var result = await coffeeCupIngredientService.GetCoffeeCupIngredientByIdAsync(coffeeCupId, ingredientId);

        // Assert
        Assert.AreEqual(expectedCoffeeCupIngredient, result);
    }

    [Test]
    public async Task GetAllCoffeeCupIngredientsAsync_ShouldReturnAllCoffeeCupIngredients()
    {
        // Arrange
        var coffeeCupId = Guid.NewGuid();
        var expectedCoffeeCupIngredients = new List<CoffeeCupIngredient>
        {
            new CoffeeCupIngredient { CoffeeCupId = coffeeCupId, IngredientId = Guid.NewGuid() },
            new CoffeeCupIngredient { CoffeeCupId = coffeeCupId, IngredientId = Guid.NewGuid() },
            // Add more as needed
        };

        var mockCoffeeCupIngredientRepository = new Mock<ICoffeeCupIngredientRepository>();
        mockCoffeeCupIngredientRepository.Setup(repo => repo.GetAllAsync(coffeeCupId)).ReturnsAsync(expectedCoffeeCupIngredients);

        var coffeeCupIngredientService = new CoffeeCupIngredientService(mockCoffeeCupIngredientRepository.Object);

        // Act
        var result = await coffeeCupIngredientService.GetAllCoffeeCupIngredientsAsync(coffeeCupId);

        // Assert
        CollectionAssert.AreEqual(expectedCoffeeCupIngredients, result.ToList());
    }

    [Test]
    public async Task AddCoffeeCupIngredientAsync_ShouldAddCoffeeCupIngredientToRepository()
    {
        // Arrange
        var coffeeCupIngredientToAdd = new CoffeeCupIngredient();

        var mockCoffeeCupIngredientRepository = new Mock<ICoffeeCupIngredientRepository>();
        var coffeeCupIngredientService = new CoffeeCupIngredientService(mockCoffeeCupIngredientRepository.Object);

        // Act
        await coffeeCupIngredientService.AddCoffeeCupIngredientAsync(coffeeCupIngredientToAdd);

        // Assert
        mockCoffeeCupIngredientRepository.Verify(repo => repo.AddAsync(coffeeCupIngredientToAdd), Times.Once);
    }

    // Add similar tests for other service methods (UpdateCoffeeCupIngredientAsync, DeleteCoffeeCupIngredientAsync, etc.)
}
