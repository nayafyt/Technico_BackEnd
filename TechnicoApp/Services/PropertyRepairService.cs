using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TechnicoApp.Dtos;
using TechnicoApp.Mappers;
using TechnicoApp.Models;
using TechnicoApp.Repositories;

namespace TechnicoApp.Services;

public class PropertyRepairService : IPropertyRepairService
{
    private readonly IRepository<PropertyRepair, long> _repository;
    private readonly IPropertyRepository<PropertyRepair, long> _propertyRepairRepository;
    private readonly IPropertyRepairRepository _propertyRepairRepository_forSearch;

    private readonly IMapper<PropertyRepair, PropertyRepairDto> _mapper;

    public PropertyRepairService(IRepository<PropertyRepair, long> repository, IPropertyRepository<PropertyRepair,long> propertyRepairService, IPropertyRepairRepository propertyRepairRepository_forSearch)
    {
        _repository = repository;
        _mapper = new PropertyRepairMapper();
        _propertyRepairRepository = propertyRepairService;
        _propertyRepairRepository_forSearch = propertyRepairRepository_forSearch;
    }

    public async Task<ResponseApi<PropertyRepairDto>> CreateAsync(PropertyRepairDto propertyRepairDto)
    {

        var propertyRepair = _mapper.GetModel(propertyRepairDto);
        if (propertyRepair == null) {
            return new ResponseApi<PropertyRepairDto>()
            {
                StatusCode = 10,
                Description = "Couldn't convert to model."
            };
        }

        //propertyRepairDto doesn t have a unique identifier so will see if we use that if  
        if (await _repository.GetAsync(propertyRepair.Id) != null)
        {
            return new ResponseApi<PropertyRepairDto>()
            {
                StatusCode = 409,
                Description = "Repair already created."
            };
        }

        //var propertyRepair = _mapper.GetModel(propertyRepairDto);

        if (propertyRepair == null)
        {
            return new ResponseApi<PropertyRepairDto>()
            {
                StatusCode = 10,
                Description = "Property repair can't convert to model."
            };
        }
        // Save property repair in repository
        await _repository.CreateAsync(propertyRepair);

        // Map the entity to DTO and return
        var resultDto = _mapper.GetDto(propertyRepair);
        return new ResponseApi<PropertyRepairDto>()
        {
            Value = resultDto,
            StatusCode = 200,
            Description = "Property successfully registered."
        };
    }


    public async Task<ResponseApi<PropertyRepairDto>> DeactivateAsync(long id)
    {
        //return await _repository.DeactivateAsync(id);
        var propertyRepair = await _repository.GetAsync(id);

        if (propertyRepair == null)
        {
            return new ResponseApi<PropertyRepairDto>()
            {
                StatusCode = 404,
                Description = "Repair not found."
            };
        }
        // Delete the property owner from the repository
        await _propertyRepairRepository.DeactivateAsync(id);
        var propertyRepairDto = _mapper.GetDto(propertyRepair);

        return new ResponseApi<PropertyRepairDto>()
        {
            Value = propertyRepairDto,
            StatusCode = 200,
            Description = "Repair deactivated successfully."
        };
    }

    public async Task<ResponseApi<bool>> DeletePermanentlyAsync(long id)
    {
        var propertyRepair = await _repository.GetAsync(id);

        if (propertyRepair == null)
        {
            return new ResponseApi<bool>()
            {
                StatusCode = 409,
                Description = "Repair not found.",
                Value = false
            };
        }
        // Delete the property repair from the repository
        await _repository.DeleteAsync(id);

        return new ResponseApi<bool>()
        {
            StatusCode = 200,
            Description = "Repair deleted successfully.",
            Value = true
        };
    }


    public async Task<ResponseApi<List<PropertyRepairDto>>> SearchByDate(DateOnly date)
    {
        // Fetch all records
        var repairs = await _propertyRepairRepository_forSearch.GetByDate(date);

        // Map results to DTOs
        var repairDtos = repairs
            .Select(r => _mapper.GetDto(r))
            .Where(dto => dto != null) // Filter out nulls
            .Cast<PropertyRepairDto>() // Cast to non-nullable type
            .ToList();


        if (repairDtos.Count == 0)
        {
            return new ResponseApi<List<PropertyRepairDto>>
            {
                StatusCode = 10,
                Description = "No repairs found for the requested DateTime."
            };
        }
        return new ResponseApi<List<PropertyRepairDto>>
        {
            Value = repairDtos,
            StatusCode = 200,
            Description = "Collection of repairs for the requested DateTime."
        };

    }

    public async Task<ResponseApi<List<PropertyRepairDto>>> SearchByUserVATNumber(string vatNumber)
    {
        // Fetch all records
        var repairs = await _propertyRepairRepository.GetByOwnerVatNumberAsync(vatNumber);

        // Map results to DTOs
        var repairDtos = repairs
            .Select(r => _mapper.GetDto(r))
            .Where(dto => dto != null) // Filter out nulls
            .Cast<PropertyRepairDto>() // Cast to non-nullable type
            .ToList();


        if (repairDtos.Count == 0)
        {
            return new ResponseApi<List<PropertyRepairDto>>
            {
                StatusCode = 10,
                Description = "No repairs found for the requested property owner."
            };
        }
        return new ResponseApi<List<PropertyRepairDto>>
        {
            Value = repairDtos,
            StatusCode = 200,
            Description = "Collection of repairs for the requested property owner."
        };
    }
 
}

    

  