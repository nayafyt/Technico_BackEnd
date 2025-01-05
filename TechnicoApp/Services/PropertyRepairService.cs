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
    private readonly IMapper<PropertyRepair, PropertyRepairDto> _mapper;

    public PropertyRepairService(IRepository<PropertyRepair, long> repository, IMapper<PropertyRepair, PropertyRepairDto> mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<ResponseApi<PropertyRepairDto>> CreateAsync(PropertyRepairDto propertyRepairDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseApi<PropertyRepairDto>> DeactivateAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseApi<bool>> DeletePermanentlyAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseApi<List<PropertyRepairDto>>> SearchByDate(DateTime dateTime)
    {
        // Fetch all records
        var repairs = await _repository.GetAsync();

        // Filter records by date
        var filteredRepairs = repairs
            .Where(r => r.DateTime.Date == dateTime.Date)
            .ToList();

        // Map results to DTOs
        var repairDtos = filteredRepairs
            .Select(r => _mapper.GetDto(r))
            .Where(dto => dto != null) // Filter out nulls
            .Cast<PropertyRepairDto>() // Cast to non-nullable type
            .ToList();


        if (repairDtos.Count == 0)
        {
            return new ResponseApi<List<PropertyRepairDto>>
            {
                StatusCode = 10,
                Description = "No repairs found for the requested date."
            };
        }
        return new ResponseApi<List<PropertyRepairDto>>
        {
            Value = repairDtos,
            StatusCode = 200,
            Description = "Collection of repairs for the requested date."
        };


    }

    public async Task<ResponseApi<List<PropertyRepairDto>>> SearchByUserVATNumber(string vatNumber)
    {
        // Fetch all records
        var repairs = await _repository.GetAsync();

        // Filter records by date
        var filteredRepairs = repairs
            .Where(r => r.PropertyOwner.VatNumber == vatNumber)
            .ToList();

        // Map results to DTOs
        var repairDtos = filteredRepairs
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