using Microsoft.AspNetCore.Mvc;
using TechnicoApp.Domain.Interfaces;
using TechnicoApp.Domain.Models;
using Technico.WebAPI.DTOs;
namespace Technico.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyItemController : ControllerBase
    {
        private readonly IPropertyItemService _service;

        public PropertyItemController(IPropertyItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<PropertyItemDTO>>> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items.Select(item => new PropertyItemDTO
            {
                Id = item.Id,
                PropertyIdentificationNumber = item.PropertyIdentificationNumber,
                Address = item.Address,
                YearOfConstruction = item.YearOfConstruction,
                PropertyType = item.PropertyType,
                OwnerVAT = item.PropertyOwnerVatNumber
            }));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PropertyItemDTO dto)
        {
            var entity = new PropertyItem
            {
                PropertyIdentificationNumber = dto.PropertyIdentificationNumber,
                Address = dto.Address,
                YearOfConstruction = dto.YearOfConstruction,
                PropertyOwnerVatNumber = dto.OwnerVAT
            };

            await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetAll), new { id = entity.Id }, entity);
        }

        [HttpDelete("permanent/{id}")]
        public async Task<IActionResult> DeletePermanently(long id)
        {
            var deletedItem = await _service.DeletePermanentlyAsync(id);
            if (deletedItem == null)
            {
                return NotFound(new { message = "Property not found." });
            }
            return Ok(new
            {
                message = "Property permanently deleted.",
                deletedItem = new
                {
                    deletedItem.Id,
                    deletedItem.PropertyIdentificationNumber,
                    deletedItem.Address,
                    deletedItem.YearOfConstruction,
                    deletedItem.PropertyOwnerVatNumber,
                    deletedItem.IsActive
                }

                });
        }

        [HttpDelete("deactivate/{id}")]
        public async Task<IActionResult> Deactivate(long id)
        {
            var deactivatedtedItem = await _service.DeactivateAsync(id); 
            if (deactivatedtedItem == null)
            {
                return NotFound(new { message = "Property not found." });
            }
            
            return Ok(new
            {
                message = "Property deactivated.",
                deactivatedItem = new
                {
                    deactivatedtedItem.Id,
                    deactivatedtedItem.PropertyIdentificationNumber,
                    deactivatedtedItem.Address,
                    deactivatedtedItem.YearOfConstruction,
                    deactivatedtedItem.PropertyOwnerVatNumber,
                    deactivatedtedItem.IsActive
                }
            });
        }

    }
}
