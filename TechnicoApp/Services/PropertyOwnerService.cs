using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Dtos;
using TechnicoApp.Mappers;
using TechnicoApp.Repositories;

namespace TechnicoApp.Services;

public class PropertyOwnerService : IPropertyOwnerService
{
    private readonly IRepository<PropertyOwner, string> _repository;
    private readonly IMapper<PropertyOwner, PropertyOwnerDto> _mapper;

    public PropertyOwnerService(IRepository<PropertyOwner, string> repository)
    {
        _repository = repository;
        _mapper = new PropertyOwnerMapper();
    }

    public ResponseApi<PropertyOwnerDto> RegisterPropertyOwner(PropertyOwnerDto propertyOwnerDto)
    {
        if (_repository.Read(propertyOwnerDto.VatNumber) != null)
        {
            return new ResponseApi<PropertyOwnerDto>() {
                StatusCode = 409,
                Description = "You are already registered."
            };
        }

        var propertyOwner = _mapper.GetModel(propertyOwnerDto);

        // Save property owner in repository
        _repository.Create(propertyOwner);

        // Map the entity to DTO and return
        var resultDto = _mapper.GetDto(propertyOwner);
        return new ResponseApi<PropertyOwnerDto>()
        {
            Value = resultDto,
            StatusCode = 200,
            Description = "You registered."
        };
    }

    public ResponseApi<PropertyOwnerDto> GetPropertyOwnerDetails(string vatNumber)
    {
        var propertyOwner = _repository.Read(vatNumber);

        if (propertyOwner == null)
        {
            return new ResponseApi<PropertyOwnerDto>()
            {
                StatusCode = 404,
                Description = "Property owner not found."
            };
        }

        var propertyOwnerDto = _mapper.GetDto(propertyOwner);

        return new ResponseApi<PropertyOwnerDto>()
        {
            Value = propertyOwnerDto,
            StatusCode = 200,
            Description = "The property owner details is shown."
        };
    }

    public ResponseApi<PropertyOwnerDto> UpdatePropertyOwner(string vatNumber, PropertyOwnerDto propertyOwnerDto)
    {
        var propertyOwner = _repository.Read(vatNumber);

        if (propertyOwner == null)
        {
            return new ResponseApi<PropertyOwnerDto>()
            {
                StatusCode = 404,
                Description = "Property owner not found."
            };
        }

        var propertyOwnerUpdated = _mapper.GetModel(propertyOwnerDto);
        // Save changes in the repository
        _repository.Update(vatNumber,propertyOwnerUpdated);

        // Map the entity to DTO and return
        var resultDto = _mapper.GetDto(propertyOwner);
        return new ResponseApi<PropertyOwnerDto>()
        {
            Value = resultDto,
            StatusCode = 200,
            Description = "Updated Property Owner Details"
        };
    }

    public ResponseApi<bool> DeletePropertyOwner(string vatNumber)
    {
        var propertyOwner = _repository.Read(vatNumber);

        if (propertyOwner == null)
        {
            return new ResponseApi<bool>() { 
                StatusCode = 409, 
                Description = "Property owner not found.",
                Value = false
            };
        }
        // Delete the property owner from the repository
        _repository.Delete(vatNumber);

        return new ResponseApi<bool>()
        {
            StatusCode = 200,
            Description = "Property owner deleted successfully.",
            Value = true
        };
    }
}
