using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;
using Service;

namespace Presentation.Controllers;

[ApiController]
[Route("api/stores")]
public class StoreController : ControllerBase
{
    private readonly IStoreService _storeService;
    private readonly IMapper _mapper;

    public StoreController(IStoreService storeService, IMapper mapper)
    {
        _storeService = storeService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStores()
    {
        var stores = await _storeService.GetAllStoresAsync();
        IEnumerable<StoreDto> storeDtos =  _mapper.Map<List<StoreDto>>(stores);
        return Ok(storeDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStoreById(Guid id)
    {
        var store = await _storeService.GetStoreByIdAsync(id);

        if (store == null)
        {
            return NotFound();
        }
        
        StoreDto storeDto = _mapper.Map<StoreDto>(store);

        return Ok(storeDto);
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
    
    [HttpGet("{storeId}/items")]
    public IActionResult GetItemsByStoreId(Guid storeId)
    {
        var items = _storeService.GetItemsByStoreId(storeId);
        _mapper.Map<List<ItemDto>>(items);
        return Ok(items);
    }
    
    
}