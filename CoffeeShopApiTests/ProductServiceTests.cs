using AutoMapper;
using Data.Repository;
using Models;
using Models.DTOs;
using Service;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;

[TestFixture]
public class ProductServiceTests
{
    private Mock<IProductRepository> mockProductRepository;
    private Mock<IMapper> mockMapper;
    private IProductService productService;

    [SetUp]
    public void Setup()
    {
        // Arrange
        mockProductRepository = new Mock<IProductRepository>();
        mockMapper = new Mock<IMapper>();

        productService = new ProductService(mockMapper.Object, mockProductRepository.Object);
    }

    [Test]
    public void GetProductById_ShouldReturnCorrectProduct()
    {
        // Arrange
        Guid productId = Guid.NewGuid();
        var productEntity = new Product { ProductID = productId, Name = "Espresso", Price = 3.99m, StockQuantity = 50 };
        var productDto = new ProductDto { ProductID = productId, Name = "Espresso", Price = 3.99m, StockQuantity = 50 };

        mockProductRepository.Setup(repo => repo.GetProductById(productId)).Returns(productEntity);
        mockMapper.Setup(mapper => mapper.Map<ProductDto>(productEntity)).Returns(productDto);

        // Act
        var result = productService.GetProductById(productId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(productDto.ProductID, result.ProductID);
        Assert.AreEqual(productDto.Name, result.Name);
        Assert.AreEqual(productDto.Price, result.Price);
        Assert.AreEqual(productDto.StockQuantity, result.StockQuantity);
    }

    [Test]
    public void GetAllProducts_ShouldReturnAllProducts()
    {
        // Arrange
        var productEntities = new List<Product>
        {
            new Product { ProductID = Guid.NewGuid(), Name = "Cappuccino", Price = 4.99m, StockQuantity = 30 },
            new Product { ProductID = Guid.NewGuid(), Name = "Latte", Price = 5.99m, StockQuantity = 20 }
        };

        var productDtos = new List<ProductDto>
        {
            new ProductDto
                { ProductID = productEntities[0].ProductID, Name = "Cappuccino", Price = 4.99m, StockQuantity = 30 },
            new ProductDto
                { ProductID = productEntities[1].ProductID, Name = "Latte", Price = 5.99m, StockQuantity = 20 }
        };

        mockProductRepository.Setup(repo => repo.GetAllProducts()).Returns(productEntities);
        mockMapper.Setup(mapper => mapper.Map<List<ProductDto>>(productEntities)).Returns(productDtos);

        // Act
        var result = productService.GetAllProducts();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(productDtos[0].ProductID, result[0].ProductID);
        Assert.AreEqual(productDtos[1].Name, result[1].Name);
        Assert.AreEqual(productDtos[1].StockQuantity, result[1].StockQuantity);
    }

    [Test]
    public void AddProduct_ShouldAddProduct()
    {
        // Arrange
        var productDto = new ProductDto { Name = "New Product", Price = 6.99m, StockQuantity = 40 };
        var productEntity = new Product
            { ProductID = Guid.NewGuid(), Name = "New Product", Price = 6.99m, StockQuantity = 40 };

        mockMapper.Setup(mapper => mapper.Map<Product>(productDto)).Returns(productEntity);

        // Act
        productService.AddProduct(productDto);

        // Assert
        mockProductRepository.Verify(repo => repo.AddProduct(productEntity), Times.Once);
    }

    [Test]
    public void UpdateProduct_ShouldUpdateProduct()
    {
        // Arrange
        Guid productId = Guid.NewGuid();
        var productDto = new ProductDto
            { ProductID = productId, Name = "Updated Product", Price = 7.99m, StockQuantity = 25 };
        var productEntity = new Product
            { ProductID = productId, Name = "Updated Product", Price = 7.99m, StockQuantity = 25 };

        mockMapper.Setup(mapper => mapper.Map<Product>(productDto)).Returns(productEntity);

        // Act
        productService.UpdateProduct(productDto);

        // Assert
        mockProductRepository.Verify(repo => repo.UpdateProduct(productEntity), Times.Once);
    }

    [Test]
    public void DeleteProduct_ShouldDeleteProduct()
    {
        // Arrange
        Guid productId = Guid.NewGuid();

        // Act
        productService.DeleteProduct(productId);

        // Assert
        mockProductRepository.Verify(repo => repo.DeleteProduct(productId), Times.Once);
    }
}