using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicoApp.Context;
using TechnicoApp.Dtos;
using TechnicoApp.Services;

namespace Technico.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertyOwnersController : ControllerBase
{
    private readonly IPropertyOwnerService _service;

    public PropertyOwnersController(IPropertyOwnerService service)
    {
        _service = service;
    }

    [HttpGet("{vatNumber}")]
    public async Task<IActionResult> GetDetails(string vatNumber)
    {
        var result = await _service.GetDetailsAsync(vatNumber);
        if (result.Value == null)
        {
            return NotFound(result);
        }
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAsync();
        if (result.Value == null)
        {
            return NotFound(result);
        }
        return Ok(result);
    }
    [HttpGet("ByPage")]
    public async Task<IActionResult> GetByPage(int pageCount=1, int pageSize=20)
    {
        var result = await _service.GetAsync(pageCount,pageSize);
        if (result.Value == null)
        {
            return NotFound(result);
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] PropertyOwnerDto dto)
    {
        var result = await _service.RegisterAsync(dto);
        if (result.StatusCode == 409)
        {
            return Conflict(result);
        }
        return CreatedAtAction(nameof(GetDetails), new { vatNumber = result?.Value?.VatNumber }, result);
    }

    [HttpPut("{vatNumber}")]
    public async Task<IActionResult> Update(string vatNumber, [FromBody] PropertyOwnerDto dto)
    {
        var result = await _service.UpdateAsync(vatNumber, dto);
        if (result.Value == null)
        {
            return NotFound(result);
        }
        return Ok(result);
    }

    [HttpDelete("{vatNumber}")]
    public async Task<IActionResult> Delete(string vatNumber)
    {
        var result = await _service.DeleteAsync(vatNumber);
        if (!result.Value)
        {
            return NotFound(result);
        }
        return NoContent();
    }
}
