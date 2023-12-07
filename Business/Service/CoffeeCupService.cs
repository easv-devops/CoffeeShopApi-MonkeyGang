using AutoMapper;
using Data;
using Data.Repository;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTOs;
using Repository;

namespace Service;

public class CoffeeCupService : ICoffeeCupService
{
    // det her er en dårlig ide

    private readonly IItemRepository _itemRepository;
    private readonly ICoffeeCupRepository _coffeeCupRepository;

    private readonly IMapper _mapper;

    //janky
    private readonly CoffeeShopDbContext _dbContext;

    public CoffeeCupService(IItemRepository itemRepository, ICoffeeCupRepository coffeeCupRepository, IMapper mapper,
        CoffeeShopDbContext dbContext)
    {
        _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        _coffeeCupRepository = coffeeCupRepository ?? throw new ArgumentNullException(nameof(coffeeCupRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        //janky
        _dbContext = dbContext;
    }

    public void CreateCoffeeCupWithItem(CoffeeCupDto coffeeCupDto)
    {
        // Map the DTO to the domain models
        var newItem = _mapper.Map<Item>(coffeeCupDto);
        var newCoffeeCup = _mapper.Map<CoffeeCup>(coffeeCupDto);

        // Set the ItemId in CoffeeCup to reference the new Item
        newCoffeeCup.ItemId = newItem.ItemId;

        // Save the new Item and CoffeeCup
        _itemRepository.AddItemAsync(newItem);
        _coffeeCupRepository.AddCoffeeCup(newCoffeeCup);
    }


    public CoffeeCupDto GetCoffeeCupById(Guid coffeeCupId)
    {
        var coffeeCupEntity = _coffeeCupRepository.GetCoffeeCupById(coffeeCupId);
        return _mapper.Map<CoffeeCupDto>(coffeeCupEntity);
    }

    public List<CoffeeCupDto> GetAllCoffeeCups()
    {
        var coffeeCupEntities = _coffeeCupRepository.GetAllCoffeeCups();
        return _mapper.Map<List<CoffeeCupDto>>(coffeeCupEntities);
    }

    public async Task<CoffeeCupDto> AddCoffeeCupAsync(CoffeeCupDto coffeeCupDto)
    {
        var newItem = new Item
        {
            ItemId = coffeeCupDto.ItemId,
            ItemType = coffeeCupDto.ItemType,
            Name = coffeeCupDto.Name,
            Price = coffeeCupDto.Price,
            Description = coffeeCupDto.Description,
            Image = coffeeCupDto.Image,

            StoreId = coffeeCupDto.StoreId
        };

        Console.WriteLine("Adding item to db");
        Guid id = await _itemRepository.AddItemAsync(newItem);

        Console.WriteLine("Item added to db");
        Console.WriteLine("Getting new item id: " + newItem.ItemId);

        Guid generatedItemId = id;


        CoffeeCup coffeeCupEntity = _mapper.Map<CoffeeCup>(coffeeCupDto);
        coffeeCupEntity.ItemId = generatedItemId;
        _coffeeCupRepository.AddCoffeeCup(coffeeCupEntity);

        return _mapper.Map<CoffeeCupDto>(coffeeCupEntity);
    }

    public void UpdateCoffeeCup(CoffeeCupDto coffeeCupDto)
    {
        var coffeeCupEntity = _mapper.Map<CoffeeCup>(coffeeCupDto);
        _coffeeCupRepository.UpdateCoffeeCup(coffeeCupEntity);
    }

    public void DeleteCoffeeCup(Guid coffeeCupId)
    {
        _coffeeCupRepository.DeleteCoffeeCup(coffeeCupId);
    }
}