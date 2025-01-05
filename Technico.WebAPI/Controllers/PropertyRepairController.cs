using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicoApp.Domain.Interfaces;
using TechnicoApp.Dtos;
using TechnicoApp.Models;
using TechnicoApp.Repositories;
using TechnicoApp.Services;

namespace TechnicoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyRepairController : ControllerBase
    {
        private readonly IPropertyRepairService _service;

        public PropertyRepairController(IPropertyRepairService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] PropertyRepairDto propertyRepairDto)
        {
            if (propertyRepairDto == null)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Description = "Invalid property repair data."
                });
            }

            var result = await _service.CreateAsync(propertyRepairDto);
            return Ok(new
            {
                StatusCode = 201,
                Description = "Property repair created successfully.",
                Data = result
            });
        }

        [HttpDelete("Permanent/{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _service.DeletePermanentlyAsync(id);
            if (!result.Value)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Description = "Property repair not found."
                });
            }

            return Ok(new
            {
                StatusCode = 200,
                Description = "Property repair deleted successfully."
            });
        }

        [HttpDelete("Deactivate/{id}")]
        public async Task<IActionResult> DeactivateAsync(long id)
        {
            var result = await _service.DeactivateAsync(id);
            if (result == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Description = "Property repair not found."
                });
            }

            return Ok(new
            {
                StatusCode = 200,
                Description = "Property repair deactivated successfully.",
                Data = result
            });
        }

        [HttpGet("search-by-vat-number")]
        public async Task<IActionResult> GetByOwnerVatNumberAsync([FromQuery] string vatNumber)
        {
            if (string.IsNullOrWhiteSpace(vatNumber))
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Description = "VAT number is required."
                });
            }

            var results = await _service.SearchByUserVATNumber(vatNumber);
            if (results.Value == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Description = "Can't happen."
                });
            }
            if (results.Value.Equals(0))
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Description = "No property repairs found for the provided VAT number."
                });
            }

            return Ok(new
            {
                StatusCode = 200,
                Description = "Property repairs retrieved successfully.",
                Data = results
            });
        }

        [HttpGet("search-by-date")]
        public async Task<IActionResult> GetByDateAsync([FromQuery] DateTime dateTime)
        {
            var results = await _service.SearchByDate(dateTime);
            if (results.Value == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Description = "Can't happen."
                });
            }

            if (results.Value.Equals(0))
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Description = "No property repairs found for the provided date."
                });
            }

            return Ok(new
            {
                StatusCode = 200,
                Description = "Property repairs retrieved successfully.",
                Data = results
            });
        }
    }
}