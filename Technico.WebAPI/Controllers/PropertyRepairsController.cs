using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicoApp.Context;
using TechnicoApp.Domain.Interfaces;
using TechnicoApp.Dtos;
using TechnicoApp.Mappers;
using TechnicoApp.Models;
using TechnicoApp.Services;

namespace Technico.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyRepairsController : ControllerBase
    {
        private readonly IPropertyRepairService _service;
        private readonly IMapper<PropertyRepair, PropertyRepairDto> _mapper;

        public PropertyRepairsController(IPropertyRepairService service)
        {
            _service = service;
            _mapper = new PropertyRepairMapper();
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PropertyRepairDto dto)
        {
            var result = await _service.CreateAsync(dto);
            var result_model = _mapper.GetModel(dto);
            if (result.StatusCode == 409)
            {
                return Conflict(result);
            }
            return CreatedAtAction(nameof(SearchByUserVatNumber), new { id = result_model.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] PropertyRepairDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (result.Value == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        // DELETE: api/PropertyRepairs/5

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

        [HttpGet("search-by-date")]
        public async Task<IActionResult> SearchByDate([FromQuery] DateOnly date)
        {
            var response = await _service.SearchByDate(date);

            if (response.StatusCode == 10)
            {
                return NotFound(new { response.Description });
            }

            return Ok(new { response.Value, response.Description });
        }

        [HttpGet("search-by-vat")]
        public async Task<IActionResult> SearchByUserVatNumber([FromQuery] string vatNumber)
        {
            if (string.IsNullOrWhiteSpace(vatNumber))
            {
                return BadRequest(new { Description = "VAT number is required." });
            }

            var response = await _service.SearchByUserVATNumber(vatNumber);

            if (response.StatusCode == 10)
            {
                return NotFound(new { response.Description });
            }

            return Ok(new { response.Value, response.Description });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            if (result.Value == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }



    }
}
