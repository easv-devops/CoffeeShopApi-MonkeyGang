using AutoMapper;
using Models;
using Models.DTOs;
using Models.Utility;

//using Models;

namespace Presentation;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CoffeeCupDto, CoffeeCup>()
            .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size))
            // Map other properties...
            .IncludeBase<ItemDto, Item>(); // Include base class mapping

        CreateMap<CoffeeCup, CoffeeCupDto>()
            .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size))
            // Map other properties...
            .IncludeBase<Item, ItemDto>(); // Include base class mapping

        CreateMap<ItemDto, Item>();
        CreateMap<Item, ItemDto>();

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