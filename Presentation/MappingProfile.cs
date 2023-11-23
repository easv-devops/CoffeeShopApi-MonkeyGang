using AutoMapper;
using Models;
using Presentation.DTOs;

//using Models;

namespace Presentation;

public class MappingProfile :  Profile
{
    public MappingProfile()
    {
        
        CreateMap<CoffeeCup, CoffeeCupDto>();

        // Add similar CreateMap lines for other models and DTOs
        CreateMap<Ingredient, IngredientDto>();
        CreateMap<Product, ProductDto>();
        CreateMap<Customer, CustomerDto>();
        CreateMap<Order, OrderDto>();
        CreateMap<OrderDetail, OrderDetailDto>();
        
    }
}