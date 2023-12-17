using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Models;
using Models.DTOs.Create;
using Models.DTOs.Response;
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
        public async Task GetCoffeeCupByIdAsync_ShouldReturnMappedCoffeeCup()
        {
            var coffeeCupId = Guid.NewGuid();
            var coffeeCup = new CoffeeCup { ItemId = coffeeCupId };
            var expectedCoffeeCupDto = new CoffeeCupResponseDto { ItemId = coffeeCupId };

            _coffeeCupRepositoryMock.Setup(repo => repo.GetByIdAsync(coffeeCupId))
                .ReturnsAsync(coffeeCup);
            _mapperMock.Setup(mapper => mapper.Map<CoffeeCupResponseDto>(coffeeCup))
                .Returns(expectedCoffeeCupDto);

            var result = await _coffeeCupService.GetCoffeeCupByIdAsync(coffeeCupId);

            Assert.That(result, Is.EqualTo(expectedCoffeeCupDto));
        }

        [Test]
        public async Task GetAllCoffeeCupsAsync_ShouldReturnMappedCoffeeCups()
        {
            var coffeeCups = new List<CoffeeCup>
            {
                new CoffeeCup { ItemId = Guid.NewGuid() },
                new CoffeeCup { ItemId = Guid.NewGuid() },
            };
            var expectedCoffeeCupDtos = new List<CoffeeCupResponseDto>
            {
                new CoffeeCupResponseDto { ItemId = coffeeCups[0].ItemId },
                new CoffeeCupResponseDto { ItemId = coffeeCups[1].ItemId },
            };

            _coffeeCupRepositoryMock.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(coffeeCups);
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<CoffeeCupResponseDto>>(coffeeCups))
                .Returns(expectedCoffeeCupDtos);

            var result = await _coffeeCupService.GetAllCoffeeCupsAsync();

            Assert.That(result, Is.EqualTo(expectedCoffeeCupDtos));
        }

        [Test]
        public async Task AddCoffeeCupAsync_ShouldReturnGeneratedId()
        {
            var createDto = new CreateCoffeeCupDto();
            var coffeeCup = new CoffeeCup();
            var generatedId = Guid.NewGuid();

            _mapperMock.Setup(mapper => mapper.Map<CoffeeCup>(createDto))
                .Returns(coffeeCup);
            _coffeeCupRepositoryMock.Setup(repo => repo.AddAsync(coffeeCup))
                .Returns(Task.CompletedTask)
                .Callback(() => coffeeCup.ItemId = generatedId);

            var result = await _coffeeCupService.AddCoffeeCupAsync(createDto);

            Assert.That(result, Is.EqualTo(generatedId));
        }

        [Test]
        public async Task GetCakesForCoffeeCupAsync_ShouldReturnMappedCakes()
        {
            var coffeeCupId = Guid.NewGuid();
            var cakesForCoffeeCup = new List<Cake> { new Cake { ItemId = Guid.NewGuid() } };
            var expectedCakeDtos = new List<CakeResponseDto>
            {
                new CakeResponseDto { ItemId = cakesForCoffeeCup[0].ItemId },
            };

            _coffeeCupRepositoryMock.Setup(repo => repo.GetCakesForCoffeeCupAsync(coffeeCupId))
                .ReturnsAsync(cakesForCoffeeCup);
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<CakeResponseDto>>(cakesForCoffeeCup))
                .Returns(expectedCakeDtos);

            var result = await _coffeeCupService.GetCakesForCoffeeCupAsync(coffeeCupId);

            Assert.That(result, Is.EqualTo(expectedCakeDtos));
        }
    }
}
