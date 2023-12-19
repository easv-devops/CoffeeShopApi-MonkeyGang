using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;
using Service;

namespace Presentation.Controllers;

[ApiController]
[Route("api/items")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;
    private readonly IMapper _mapper;


    public ItemController(IItemService itemService, IMapper mapper)
    {
        _itemService = itemService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllItems()
    {
        var items = await _itemService.GetAllItemsAsync();

        IEnumerable<ItemDto> itemDtos = _mapper.Map<List<ItemDto>>(items);

        return Ok(itemDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemById(Guid id)
    {
        var item = await _itemService.GetItemByIdAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        ItemDto itemDto = _mapper.Map<ItemDto>(item);

        return Ok(itemDto);
    }


    [HttpPost]
    public async Task<IActionResult> AddItem([FromBody] Item item)
    {
        if (item == null)
        {
            return BadRequest("Item object is null");
        }

        await _itemService.AddItemAsync(item);

        return CreatedAtAction(nameof(GetItemById), new { id = item.ItemId }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(Guid id, [FromBody] Item item)
    {
        if (item == null || id != item.ItemId)
        {
            return BadRequest("Invalid request");
        }

        var existingItem = await _itemService.GetItemByIdAsync(id);
        if (existingItem == null)
        {
            return NotFound();
        }

        await _itemService.UpdateItemAsync(item);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(Guid id)
    {
        var item = await _itemService.GetItemByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        await _itemService.DeleteItemAsync(id);

        return NoContent();
    }
}