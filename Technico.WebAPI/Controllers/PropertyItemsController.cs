using Microsoft.AspNetCore.Mvc;
using TechnicoApp.Domain.Interfaces;
using TechnicoApp.Dtos;

namespace Technico.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyItemsController : ControllerBase
{
    private readonly IPropertyItemService _service;


    public PropertyItemsController(IPropertyItemService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result.Value == null)
        {
            return NotFound(result);
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PropertyItemDto dto)
    {
        var result = await _service.CreateAsync(dto);
        if (result.StatusCode == 409)
        {
            return Conflict(result);
        }
        return CreatedAtAction(nameof(GetById), new { id = result.Value.PropertyIdentificationNumber }, result);
    }

    [HttpDelete("Permanent/{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _service.DeletePermanentlyAsync(id);
        if (!result.Value)
        {
            return NotFound(result);
        }
        return NoContent();
    }

    [HttpDelete("Deactivate/{id}")]
    public async Task<IActionResult> SoftDelete(long id)
    {
        var result = await _service.DeactivateAsync(id);
        if (result.Value == null)
        {
            return NotFound(result);
        }
        return NoContent();
    }
}
