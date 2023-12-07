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
        var mockRepository = new Mock<IBrandRepository>();
        mockRepository.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(new List<Brand>
            {
                new Brand { BrandId = Guid.NewGuid(), Name = "Brand1" },
                new Brand { BrandId = Guid.NewGuid(), Name = "Brand2" }
            });

        var brandService = new BrandService(mockRepository.Object);

        var result = await brandService.GetAllBrandsAsync();

        Assert.NotNull(result);
        Assert.AreEqual(2, result.Count());
    }

    [Test]
    public async Task GetBrandByIdAsync_ExistingId_ShouldReturnBrand()
    {
        var existingBrandId = Guid.NewGuid();
        var existingBrand = new Brand { BrandId = existingBrandId, Name = "ExistingBrand" };

        var mockRepository = new Mock<IBrandRepository>();
        mockRepository.Setup(repo => repo.GetByIdAsync(existingBrandId))
            .ReturnsAsync(existingBrand);

        var brandService = new BrandService(mockRepository.Object);

        var result = await brandService.GetBrandByIdAsync(existingBrandId);

        Assert.NotNull(result);
        Assert.AreEqual(existingBrandId, result.BrandId);
    }

    [Test]
    public async Task AddBrandAsync_ValidBrand_ShouldAddBrand()
    {
        var newBrand = new Brand { BrandId = Guid.NewGuid(), Name = "NewBrand" };

        var mockRepository = new Mock<IBrandRepository>();
        var brandService = new BrandService(mockRepository.Object);

        await brandService.AddBrandAsync(newBrand);

        mockRepository.Verify(repo => repo.AddAsync(newBrand), Times.Once);
    }

    [Test]
    public async Task UpdateBrandAsync_ExistingBrand_ShouldUpdateBrand()
    {
        var existingBrandId = Guid.NewGuid();
        var existingBrand = new Brand { BrandId = existingBrandId, Name = "ExistingBrand" };

        var mockRepository = new Mock<IBrandRepository>();
        mockRepository.Setup(repo => repo.GetByIdAsync(existingBrandId))
            .ReturnsAsync(existingBrand);

        var brandService = new BrandService(mockRepository.Object);

        await brandService.UpdateBrandAsync(existingBrand);

        mockRepository.Verify(repo => repo.UpdateAsync(existingBrand), Times.Once);
    }

    [Test]
    public async Task DeleteBrandAsync_ExistingBrandId_ShouldDeleteBrand()
    {
        var existingBrandId = Guid.NewGuid();
        var existingBrand = new Brand { BrandId = existingBrandId, Name = "ExistingBrand" };

        var mockRepository = new Mock<IBrandRepository>();
        mockRepository.Setup(repo => repo.GetByIdAsync(existingBrandId))
            .ReturnsAsync(existingBrand);

        var brandService = new BrandService(mockRepository.Object);

        await brandService.DeleteBrandAsync(existingBrandId);

        mockRepository.Verify(repo => repo.DeleteAsync(existingBrandId), Times.Once);
    }
}