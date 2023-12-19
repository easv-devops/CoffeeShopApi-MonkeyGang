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
        // (╯°□°）╯︵ ┻━┻
        CreateMap<Item, ItemResponseDto>();
        CreateMap<ItemResponseDto, Item>();
        CreateMap<ItemDto, Item>();
        CreateMap<CreateItemDto, Item>();
        CreateMap<Item, ItemDto>();
        CreateMap<ItemResponseDto, CakeResponseDto>();
        CreateMap<CakeResponseDto, ItemResponseDto>();

        CreateMap<CoffeeCupDto, CoffeeCup>()
            // Map other properties...
            .IncludeBase<ItemDto, Item>(); // Include base class mapping

        CreateMap<CoffeeCup, CoffeeCupDto>()
            .IncludeBase<Item, ItemDto>() // Include the base class mapping
            .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
            .ForMember(dest => dest.Ingredients,
                opt => opt.MapFrom(src => src.CoffeeCupIngredients.Select(cci => cci.Ingredient)));


        CreateMap<CoffeeCup, CoffeeCupResponseDto>()
            .IncludeBase<Item, ItemResponseDto>() // Include the base class mapping
            .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
            .ForMember(dest => dest.Ingredients,
                opt => opt.MapFrom(src => src.CoffeeCupIngredients.Select(cci => cci.Ingredient)))
            .ForMember(dest => dest.StoreIds,
                opt => opt.MapFrom(src => src.StoreItems.Select(si => si.StoreId).ToList()));


        CreateMap<CreateCoffeeCupDto, CoffeeCup>()
            // Map other properties...
            .IncludeBase<CreateItemDto, Item>(); // Include base class mapping

        //CreateMap<CoffeeCup, CreateCoffeeCupDto>();


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

        CreateMap<User, UserDto>();


        CreateMap<UserDto, User>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(new PasswordResolver()))
            .ForMember(dest => dest.Orders, opt => opt.Ignore())
            .ForMember(dest => dest.Posts, opt => opt.Ignore());

        CreateMap<CreateUserDTO, User>();
        CreateMap<User, CreateUserDTO>();
        CreateMap<User, UserResponseDto>();


        CreateMap<Order, OrderDto>();
        CreateMap<OrderDto, Order>();
        CreateMap<CreateOrderDto, Order>();
        CreateMap<Order, OrderResponseDto>()
            .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));
        CreateMap<OrderResponseDto, Order>();


        CreateMap<OrderDetail, OrderDetailDto>();
        CreateMap<OrderDetailDto, OrderDetail>();
        CreateMap<CreateOrderDetailDto, OrderDetail>();
        CreateMap<OrderDetail, OrderDetailResponseDto>();
        CreateMap<OrderDetailResponseDto, OrderDetail>();

        CreateMap<Cake, CakeDto>();
        CreateMap<CakeDto, Cake>();

        CreateMap<CoffeeBean, CoffeeBeanDto>();
        CreateMap<CoffeeBeanDto, CoffeeBean>();

        CreateMap<Store, StoreDto>();
        CreateMap<StoreDto, Store>();


        CreateMap<Post, PostDto>();
        CreateMap<PostDto, Post>();


        CreateMap<UserDto, UserResponseDto>();

        CreateMap<Cake, CakeResponseDto>()
            .IncludeBase<Item, ItemResponseDto>();
        CreateMap<CakeResponseDto, Cake>()
            .IncludeBase<ItemResponseDto, Item>();

        CreateMap<Ingredient, IngredientDto>();
        CreateMap<IngredientDto, Ingredient>();

        CreateMap<CoffeeCupIngredient, CoffeeCupIngredientDto>();

        CreateMap<CreateCoffeeCupIngredientDto, CustomCoffeeCupDto>();
        CreateMap<CustomCoffeeCupDto, CreateCoffeeCupIngredientDto>();

        CreateMap<CustomCoffeeCupCreateDto, CustomCoffeeCup>();

        CreateMap<CustomCoffeeCupIngredients, CustomCoffeeCupIngredientsResponseDto>();


        CreateMap<CreateCustomCoffeeCupIngredientsDto, CoffeeCupIngredient>();

        CreateMap<CustomCoffeeCup, CustomCoffeeCupResponseDto>();

        CreateMap<CreatePostDto, Post>();
        CreateMap<Post, PostResponseDto>();
    }
}