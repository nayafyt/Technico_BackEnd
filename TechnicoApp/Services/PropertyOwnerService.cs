using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using TechnicoApp.Domain.Infrastructure.Repositories;
using TechnicoApp.Domain.Models;
using TechnicoApp.Dtos;
using TechnicoApp.Mappers;
using TechnicoApp.Repositories;

namespace TechnicoApp.Services;

/// <summary>
/// Service implementation for managing property owner data, providing functionality for
/// registering, retrieving, updating, and deleting property owner records.
/// </summary>
public class PropertyOwnerService : IPropertyOwnerService
{
    private readonly IRepository<PropertyOwner, string> _repository;
    private readonly IPropertyItemRepository _propertyItemRepository;
    private readonly IMapper<PropertyOwner, PropertyOwnerDto> _mapper;

    public PropertyOwnerService(IRepository<PropertyOwner, string> repository,IPropertyItemRepository propertyItemRepository)
    {
        _repository = repository;
        _mapper = new PropertyOwnerMapper();
        _propertyItemRepository = propertyItemRepository;
    }

    public async Task<ResponseApi<PropertyOwnerDto>> RegisterAsync(PropertyOwnerDto propertyOwnerDto)
    {
        if (await _repository.GetAsync(propertyOwnerDto.VatNumber) != null)
        {
            return new ResponseApi<PropertyOwnerDto>()
            {
                StatusCode = 409,
                Description = "You are already registered."
            };
        }

        var propertyOwner = _mapper.GetModel(propertyOwnerDto);
        if (propertyOwner == null) { 
            return new ResponseApi<PropertyOwnerDto>()
            {
                StatusCode = 10,
                Description = "Cannot convert to model."
            };
            }
        // Save property owner in repository
        await _repository.CreateAsync(propertyOwner);

        // Map the entity to DTO and return
        var resultDto = _mapper.GetDto(propertyOwner);
        return new ResponseApi<PropertyOwnerDto>()
        {
            Value = resultDto,
            StatusCode = 200,
            Description = "You registered."
        };
    }

    public async Task<ResponseApi<PropertyOwnerDto>> GetDetailsAsync(string vatNumber)
    {
        var propertyOwner = await _repository.GetAsync(vatNumber);

        if (propertyOwner == null)
        {
            return new ResponseApi<PropertyOwnerDto>()
            {
                StatusCode = 404,
                Description = "Property owner not found."
            };
        }

        // Fetch associated property items
        var propertyItems = await _propertyItemRepository.GetByOwnerVatNumberAsync(vatNumber);


        // Map property owner to DTO
        var propertyOwnerDto = _mapper.GetDto(propertyOwner);

        // Map and include property items in the DTO
        propertyOwnerDto.PropertyItems = propertyItems.Select(item => new PropertyItemDto
        { 
            PropertyIdentificationNumber = item.PropertyIdentificationNumber,
            Address = item.Address,
            YearOfConstruction = item.YearOfConstruction,
            PropertyType = item.PropertyType,
            PropertyOwnerVatNumber = item.PropertyOwnerVatNumber
        }).ToList();


        return new ResponseApi<PropertyOwnerDto>()
        {
            Value = propertyOwnerDto,
            StatusCode = 200,
            Description = "The property owner details are shown."
        };
    }

    public async Task<ResponseApi<PropertyOwnerDto>> UpdateAsync(string vatNumber, PropertyOwnerDto propertyOwnerDto)
    {
        var propertyOwner = await _repository.GetAsync(vatNumber);

        if (propertyOwner == null)
        {
            return new ResponseApi<PropertyOwnerDto>()
            {
                StatusCode = 404,
                Description = "Property owner not found."
            };
        }

        var propertyOwnerUpdated = _mapper.GetModel(propertyOwnerDto);
        if (propertyOwnerUpdated == null)
        {
            return new ResponseApi<PropertyOwnerDto>()
            {
                StatusCode = 10,
                Description = "Property owner (Dto) not parsed into Model."
            };
        }
        // Save changes in the repository
        await _repository.UpdateAsync(propertyOwnerUpdated);

        // Map the entity to DTO and return
        var resultDto = _mapper.GetDto(propertyOwnerUpdated);
        return new ResponseApi<PropertyOwnerDto>()
        {
            Value = resultDto,
            StatusCode = 200,
            Description = "Updated Property Owner Details"
        };
    }

    public async Task<ResponseApi<bool>> DeleteAsync(string vatNumber)
    {
        var propertyOwner = await _repository.GetAsync(vatNumber);

        if (propertyOwner == null)
        {
            return new ResponseApi<bool>()
            {
                StatusCode = 409,
                Description = "Property owner not found.",
                Value = false
            };
        }
        // Delete the property owner from the repository
        await _repository.DeleteAsync(vatNumber);

        return new ResponseApi<bool>()
        {
            StatusCode = 200,
            Description = "Property owner deleted successfully.",
            Value = true
        };
    }
}
