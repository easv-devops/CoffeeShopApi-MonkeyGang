

using Models;
using Models.DTOs.Response;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Repository;

namespace CoffeeShopApiTests
{
    [TestFixture]
    public class CoffeeCupServiceTests
    {
        [Test]
        public async Task GetCoffeeCupByIdAsync_ExistingId_ReturnsCoffeeCup()
        {
            var coffeeCupId = Guid.NewGuid();
            var expectedCoffeeCup = new CoffeeCup { ItemId = coffeeCupId, /* other properties */ };
            
            var coffeeCupRepositoryMock = new Mock<ICoffeeCupRepository>();
            coffeeCupRepositoryMock.Setup(repo => repo.GetByIdAsync(coffeeCupId)).ReturnsAsync(expectedCoffeeCup);

            var coffeeCupService = new CoffeeCupService(coffeeCupRepositoryMock.Object);

            var result = await coffeeCupService.GetCoffeeCupByIdAsync(coffeeCupId);

            Assert.That(result, Is.Not.Null);
            Assert.That(expectedCoffeeCup, Is.EqualTo(result));
        }

        [Test]
        public async Task GetCoffeeCupByIdAsync_NonExistentId_ReturnsNull()
        {
            var coffeeCupId = Guid.NewGuid();
            
            var coffeeCupRepositoryMock = new Mock<ICoffeeCupRepository>();
            coffeeCupRepositoryMock.Setup(repo => repo.GetByIdAsync(coffeeCupId)).ReturnsAsync((CoffeeCup)null);

            var coffeeCupService = new CoffeeCupService(coffeeCupRepositoryMock.Object);

            var result = await coffeeCupService.GetCoffeeCupByIdAsync(coffeeCupId);

            Assert.That(result, Is.Null);        }

        [Test]
        public async Task GetAllCoffeeCupsAsync_ReturnsListOfCoffeeCups()
        {
            var expectedCoffeeCups = new List<CoffeeCup>
            {
                new CoffeeCup { ItemId = Guid.NewGuid()},
                new CoffeeCup { ItemId = Guid.NewGuid()},
            };
            
            var coffeeCupRepositoryMock = new Mock<ICoffeeCupRepository>();
            coffeeCupRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expectedCoffeeCups);

            var coffeeCupService = new CoffeeCupService(coffeeCupRepositoryMock.Object);

            var result = await coffeeCupService.GetAllCoffeeCupsAsync();

            Assert.That(result, Is.Not.Null);
            //why do we use  nunit legacy here?
            CollectionAssert.AreEquivalent(expectedCoffeeCups, result);
        }

        // Add more tests for AddCoffeeCupAsync, UpdateCoffeeCupAsync, and DeleteCoffeeCupAsync as needed
    }
}
