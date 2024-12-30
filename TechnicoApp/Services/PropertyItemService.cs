using Technico.WebAPI.DTOs;
using TechnicoApp.Domain.Interfaces;
using TechnicoApp.Domain.Models;
using TechnicoApp.Dtos;
using TechnicoApp.Mappers;
using TechnicoApp.Repositories;

namespace TechnicoApp.Services;

public class PropertyItemService: IPropertyItemService
{
    private readonly IRepository<PropertyItem, long> _repository;
    private readonly IMapper<PropertyItem, PropertyItemDto> _mapper;

    public PropertyItemService(IRepository<PropertyItem, long> repository)
    {
        _repository = repository;
        _mapper = new PropertyItemMapper();
    }



    public async Task<ResponseApi<PropertyItemDto>> GetByIdAsync(long id)
    {
        // return await _repository.GetAsync(id);
        var propertyItem = await _repository.GetAsync(id);

        if (propertyItem == null)
        {
            return new ResponseApi<PropertyItemDto>()
            {
                StatusCode = 404,
                Description = "Property not found."
            };
        }

        var propertyItemDto = _mapper.GetDto(propertyItem);

        return new ResponseApi<PropertyItemDto>()
        {
            Value = propertyItemDto,
            StatusCode = 200,
            Description = "The property details are shown."
        };
    }


    public async Task<ResponseApi<PropertyItemDto>> CreateAsync(PropertyItemDto propertyItemDto)
    {
        if (await _repository.GetAsync(propertyItemDto.PropertyIdentificationNumber) != null)
        {
            return new ResponseApi<PropertyItemDto>()
            {
                StatusCode = 409,
                Description = "Property already registered."
            };
        }

        var propertyItem = _mapper.GetModel(propertyItemDto);

        // Save property owner in repository
        await _repository.CreateAsync(propertyItem);

        // Map the entity to DTO and return
        var resultDto = _mapper.GetDto(propertyItem);
        return new ResponseApi<PropertyItemDto>()
        {
            Value = resultDto,
            StatusCode = 200,
            Description = "Property successfully registered."
        };
    }

    //public async Task UpdateAsync(PropertyItem propertyItem)
    //{
    //    await _repository.UpdateAsync(propertyItem);
    //}

    public async Task<ResponseApi<bool>> DeletePermanentlyAsync(long id)
    {
        var propertyItem = await _repository.GetAsync(id);

        if (propertyItem == null)
        {
            return new ResponseApi<bool>()
            {
                StatusCode = 409,
                Description = "Property not found.",
                Value = false
            };
        }
        // Delete the property owner from the repository
        await _repository.DeleteAsync(id);

        return new ResponseApi<bool>()
        {
            StatusCode = 200,
            Description = "Property deleted successfully.",
            Value = true
        };
    }
   
    public async Task<ResponseApi<PropertyItemDto>> DeactivateAsync(long id)
    {
        //return await _repository.DeactivateAsync(id);
        var propertyItem = await _repository.GetAsync(id);

        if (propertyItem == null)
        {
            return new ResponseApi<PropertyItemDto>()
            {
                StatusCode = 404,
                Description = "Property not found."
            };
        }
        // Delete the property owner from the repository
        await _repository.DeactivateAsync(id);
        var propertyItemDto = _mapper.GetDto(propertyItem);

        return new ResponseApi<PropertyItemDto>()
        {
            Value = propertyItemDto,
            StatusCode = 200,
            Description = "Property deactivated successfully."
        };
    }

}