using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Models;
using Models.DTOs.Create;
using Models.DTOs.Response;
using Moq;
using NUnit.Framework;
using Repository;
using Service;

namespace YourProject.Tests.Service
{
    [TestFixture]
    public class CoffeeCupServiceTests
    {
        private CoffeeCupService _coffeeCupService;
        private Mock<ICoffeeCupRepository> _coffeeCupRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _coffeeCupRepositoryMock = new Mock<ICoffeeCupRepository>();
            _mapperMock = new Mock<IMapper>();

            _coffeeCupService = new CoffeeCupService(_coffeeCupRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task GetCoffeeCupByIdAsync_ShouldReturnCoffeeCup()
        {
            var coffeeCupId = Guid.NewGuid();
            var expectedCoffeeCup = new CoffeeCup { ItemId = coffeeCupId };
            _coffeeCupRepositoryMock.Setup(repo => repo.GetByIdAsync(coffeeCupId))
                .ReturnsAsync(expectedCoffeeCup);

            var result = await _coffeeCupService.GetCoffeeCupByIdAsync(coffeeCupId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ItemId, Is.EqualTo(coffeeCupId));
        }

        [Test]
        public async Task GetAllCoffeeCupsAsync_ShouldReturnAllCoffeeCups()
        {
            var expectedCoffeeCups = new List<CoffeeCup>
            {
                new CoffeeCup { ItemId = Guid.NewGuid() },
                new CoffeeCup { ItemId = Guid.NewGuid() },
            };
            _coffeeCupRepositoryMock.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(expectedCoffeeCups);

            var result = await _coffeeCupService.GetAllCoffeeCupsAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(expectedCoffeeCups.Count));
        }

        [Test]
        public async Task GetCakesForCoffeeCupAsync_ShouldReturnCakes()
        {
            var coffeeCupId = Guid.NewGuid();
            var expectedCakes = new List<Cake> { new Cake { ItemId = Guid.NewGuid() } };
            _coffeeCupRepositoryMock.Setup(repo => repo.GetCakesForCoffeeCupAsync(coffeeCupId))
                .ReturnsAsync(expectedCakes);

            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<CakeResponseDto>>(expectedCakes))
                .Returns(new List<CakeResponseDto> { new CakeResponseDto { ItemId = expectedCakes[0].ItemId } });

            var result = await _coffeeCupService.GetCakesForCoffeeCupAsync(coffeeCupId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ToList()[0].ItemId, Is.EqualTo(expectedCakes[0].ItemId));
        }
    }
}
