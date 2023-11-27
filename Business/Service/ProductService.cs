using Data.Repository;
using Models;
using Presentation.DTOs;

namespace Service;

using AutoMapper;
using System;
using System.Collections.Generic;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductService(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public ProductDto GetProductById(Guid id)
    {
        var product = _productRepository.GetProductById(id);
        return _mapper.Map<ProductDto>(product);
    }

    public List<ProductDto> GetAllProducts()
    {
        var products = _productRepository.GetAllProducts();
        return _mapper.Map<List<ProductDto>>(products);
    }

    public void AddProduct(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        _productRepository.AddProduct(product);
    }

    public void UpdateProduct(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        _productRepository.UpdateProduct(product);
    }

    public void DeleteProduct(Guid id)
    {
        _productRepository.DeleteProduct(id);
    }
}