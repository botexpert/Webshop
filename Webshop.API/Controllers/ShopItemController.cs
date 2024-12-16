using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webshop.Application.DTOs;
using Webshop.Application.Interfaces;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class ShopItemsController : ControllerBase
{
    private readonly IShopItemService _service;

    public ShopItemsController(IShopItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.GetAllItemsAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _service.GetItemByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ShopItemDto itemDto) =>
        CreatedAtAction(nameof(GetById), new { id = itemDto.Id }, await _service.AddItemAsync(itemDto));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ShopItemDto itemDto)
    {
        await _service.UpdateItemAsync(id, itemDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteItemAsync(id);
        return NoContent();
    }
}
