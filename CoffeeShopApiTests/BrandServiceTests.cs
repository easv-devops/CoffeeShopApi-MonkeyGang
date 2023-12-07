
using Moq;
using NUnit.Framework;
using Data.Repository.Interfaces;
using Models;
using Service;


namespace CoffeeShopApiTests;
using System;

using System.Threading.Tasks;
using System.Collections.Generic;

[TestFixture]
public class BrandServiceTests
{
    [Test]
    public async Task GetAllBrandsAsync_ShouldReturnAllBrands()
    {
        // Arrange
        var mockRepository = new Mock<IBrandRepository>();
        mockRepository.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(new List<Brand>
            {
                new Brand { BrandId = Guid.NewGuid(), Name = "Brand1" },
                new Brand { BrandId = Guid.NewGuid(), Name = "Brand2" }
            });

        var brandService = new BrandService(mockRepository.Object);

        // Act
        var result = await brandService.GetAllBrandsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.AreEqual(2, result.Count());
    }

    [Test]
    public async Task GetBrandByIdAsync_ExistingId_ShouldReturnBrand()
    {
        // Arrange
        var existingBrandId = Guid.NewGuid();
        var existingBrand = new Brand { BrandId = existingBrandId, Name = "ExistingBrand" };

        var mockRepository = new Mock<IBrandRepository>();
        mockRepository.Setup(repo => repo.GetByIdAsync(existingBrandId))
            .ReturnsAsync(existingBrand);

        var brandService = new BrandService(mockRepository.Object);

        // Act
        var result = await brandService.GetBrandByIdAsync(existingBrandId);

        // Assert
        Assert.NotNull(result);
        Assert.AreEqual(existingBrandId, result.BrandId);
    }

    [Test]
    public async Task AddBrandAsync_ValidBrand_ShouldAddBrand()
    {
        // Arrange
        var newBrand = new Brand { BrandId = Guid.NewGuid(), Name = "NewBrand" };

        var mockRepository = new Mock<IBrandRepository>();
        var brandService = new BrandService(mockRepository.Object);

        // Act
        await brandService.AddBrandAsync(newBrand);

        // Assert
        mockRepository.Verify(repo => repo.AddAsync(newBrand), Times.Once);
    }

    [Test]
    public async Task UpdateBrandAsync_ExistingBrand_ShouldUpdateBrand()
    {
        // Arrange
        var existingBrandId = Guid.NewGuid();
        var existingBrand = new Brand { BrandId = existingBrandId, Name = "ExistingBrand" };

        var mockRepository = new Mock<IBrandRepository>();
        mockRepository.Setup(repo => repo.GetByIdAsync(existingBrandId))
            .ReturnsAsync(existingBrand);

        var brandService = new BrandService(mockRepository.Object);

        // Act
        await brandService.UpdateBrandAsync(existingBrand);

        // Assert
        mockRepository.Verify(repo => repo.UpdateAsync(existingBrand), Times.Once);
    }

    [Test]
    public async Task DeleteBrandAsync_ExistingBrandId_ShouldDeleteBrand()
    {
        // Arrange
        var existingBrandId = Guid.NewGuid();
        var existingBrand = new Brand { BrandId = existingBrandId, Name = "ExistingBrand" };

        var mockRepository = new Mock<IBrandRepository>();
        mockRepository.Setup(repo => repo.GetByIdAsync(existingBrandId))
            .ReturnsAsync(existingBrand);

        var brandService = new BrandService(mockRepository.Object);

        // Act
        await brandService.DeleteBrandAsync(existingBrandId);

        // Assert
        mockRepository.Verify(repo => repo.DeleteAsync(existingBrandId), Times.Once);
    }
}