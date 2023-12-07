using Microsoft.AspNetCore.Mvc;
using Models;
using Service;

namespace Presentation.Controllers;

[ApiController]
[Route("api/items")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllItems()
    {
        var items = await _itemService.GetAllItemsAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemById(Guid id)
    {
        var item = await _itemService.GetItemByIdAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpGet("by-store/{storeId}")]
    public async Task<IActionResult> GetItemsByStoreId(Guid storeId)
    {
        var items = await _itemService.GetItemsByStoreIdAsync(storeId);
        return Ok(items);
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