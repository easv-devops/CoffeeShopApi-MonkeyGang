using AutoMapper;
using Models;
using Models.DTOs;
using Models.DTOs.Create;
using Models.DTOs.Response;
using Models.Utility;

//using Models;

namespace Presentation;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
        CreateMap<Item, ItemResponseDto>(); // Map the base class
        CreateMap<ItemDto, Item>();
        CreateMap<CreateItemDto, Item>();
        CreateMap<Item, ItemDto>();
        
        
        CreateMap<CoffeeCupDto, CoffeeCup>()
            // Map other properties...
            .IncludeBase<ItemDto, Item>(); // Include base class mapping

        CreateMap<CoffeeCup, CoffeeCupDto>()
            .IncludeBase<Item, ItemDto>() // Include the base class mapping
            .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.CoffeeCupIngredients.Select(cci => cci.Ingredient)));


        CreateMap<CoffeeCup, CoffeeCupResponseDto>()
            .IncludeBase<Item, ItemResponseDto>() // Include the base class mapping
            
            .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.CoffeeCupIngredients.Select(cci => cci.Ingredient)));


        
        CreateMap<CreateCoffeeCupDto, CoffeeCup>()
            // Map other properties...
            .IncludeBase<CreateItemDto, Item>(); // Include base class mapping
        
        //CreateMap<CoffeeCup, CreateCoffeeCupDto>();

        CreateMap<CoffeeCup, CoffeeCupResponseDto>()
            .IncludeBase<Item, ItemResponseDto>()
            .ForMember(dest => dest.Ingredients,
                opt => opt.MapFrom(src => src.CoffeeCupIngredients.Select(cci => cci.Ingredient)));
            
        CreateMap<CoffeeCupResponseDto, CoffeeCup>();

        CreateMap<IngredientResponseDto, Ingredient>();
        CreateMap<Ingredient, IngredientResponseDto>();
        


        CreateMap<CoffeeCupIngredientDto, CoffeeCupIngredient>()
            .ForMember(dest => dest.CoffeeCupId, opt => opt.MapFrom(src => src.CoffeeCupId))
            .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.IngredientId))
            .ForMember(dest => dest.Ingredient, opt => opt.MapFrom(src => src.Ingredient));

        // Add similar CreateMap lines for other models and DTOs
        CreateMap<Ingredient, IngredientDto>();
        CreateMap<IngredientDto, Ingredient>();
        //???????????????
        //CreateMap(CoffeeCupIngredient, CoffeeCupIngredientDto>();

        CreateMap<Customer, CustomerDto>();


        CreateMap<CustomerDto, Customer>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(new PasswordResolver()))
            .ForMember(dest => dest.Orders, opt => opt.Ignore())
            .ForMember(dest => dest.Posts, opt => opt.Ignore());

        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<Customer, CreateCustomerDto>();
        CreateMap<Customer, CustomerResponseDto>();

        
        CreateMap<Order, OrderDto>();
        CreateMap<OrderDto, Order>();
        CreateMap<OrderDetail, OrderDetailDto>();
        CreateMap<OrderDetailDto, OrderDetail>();

        CreateMap<Cake, CakeDto>();
        CreateMap<CakeDto, Cake>();

        CreateMap<CoffeeBean, CoffeeBeanDto>();
        CreateMap<CoffeeBeanDto, CoffeeBean>();

        CreateMap<Store, StoreDto>();
        CreateMap<StoreDto, Store>();
        

        CreateMap<Post, PostDto>();
        CreateMap<PostDto, Post>();
    }
}