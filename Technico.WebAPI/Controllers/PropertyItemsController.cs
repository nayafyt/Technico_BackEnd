using Microsoft.AspNetCore.Mvc;
using TechnicoApp.Domain.Interfaces;
using TechnicoApp.Dtos;
using TechnicoApp.Services;

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
    [HttpGet]
    public async Task<IActionResult> GetAll(int pageCount=1, int pageSize=10)
    {
        // Validate inputs
        if (pageCount <= 0 || pageSize <= 0)
        {
            return BadRequest(new { message = "PageCount and PageSize must be greater than 0." });
        }

        var result = await _service.GetAllAsync(pageCount, pageSize);

        if (result.Value == null || result.Value.Count == 0)
        {
            return NotFound(result);
        }

        return Ok(result);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
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
        if (result.StatusCode == 10)
        {
            return Conflict(result);
        }
        return CreatedAtAction(nameof(GetById), new { id = result?.Value?.PropertyIdentificationNumber }, result);
    }

    [HttpDelete("Permanent/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _service.DeletePermanentlyAsync(id);
        if (!result.Value)
        {
            return NotFound(result);
        }
        return NoContent();
    }

    [HttpDelete("Deactivate/{id}")]
    public async Task<IActionResult> SoftDelete(string id)
    {
        var result = await _service.DeactivateAsync(id);
        if (result.Value == null)
        {
            return NotFound(result);
        }
        return NoContent();
    }

    

}
