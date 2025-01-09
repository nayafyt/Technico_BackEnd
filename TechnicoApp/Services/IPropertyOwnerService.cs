using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Dtos;

namespace TechnicoApp.Services;

/// <summary>
/// Interface defining operations for managing property owner information.
/// </summary>
public interface IPropertyOwnerService
{
    Task<ResponseApi<PropertyOwnerDto>> RegisterAsync(PropertyOwnerDto propertyOwnerDto); 
    Task<ResponseApi<PropertyOwnerDto>> GetDetailsAsync(string vatNumber); 
    Task<ResponseApi<List<PropertyOwnerDto>>> GetAsync(); 
    Task<ResponseApi<PropertyOwnerDto>> UpdateAsync(string vatNumber, PropertyOwnerDto propertyOwnerDto);
    Task<ResponseApi<bool>> DeleteAsync(string vatNumber);
}
