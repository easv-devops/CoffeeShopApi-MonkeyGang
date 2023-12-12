using Microsoft.AspNetCore.Mvc;
using Models;
using Service;

namespace Presentation.Controllers;

[ApiController]
[Route("api/stores")]
public class StoreController : ControllerBase
{
    private readonly IStoreService _storeService;

    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStores()
    {
        var stores = await _storeService.GetAllStoresAsync();
        return Ok(stores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStoreById(Guid id)
    {
        var store = await _storeService.GetStoreByIdAsync(id);

        if (store == null)
        {
            return NotFound();
        }

        return Ok(store);
    }


    [HttpPost]
    public async Task<IActionResult> AddStore([FromBody] Store store)
    {
        if (store == null)
        {
            return BadRequest("Store object is null");
        }

        await _storeService.AddStoreAsync(store);

        return CreatedAtAction(nameof(GetStoreById), new { id = store.StoreId }, store);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStore(Guid id, [FromBody] Store store)
    {
        if (store == null || id != store.StoreId)
        {
            return BadRequest("Invalid request");
        }

        var existingStore = await _storeService.GetStoreByIdAsync(id);
        if (existingStore == null)
        {
            return NotFound();
        }

        await _storeService.UpdateStoreAsync(store);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStore(Guid id)
    {
        var store = await _storeService.GetStoreByIdAsync(id);
        if (store == null)
        {
            return NotFound();
        }

        await _storeService.DeleteStoreAsync(id);

        return NoContent();
    }
}