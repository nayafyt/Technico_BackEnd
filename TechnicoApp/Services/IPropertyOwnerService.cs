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
    ResponseApi<PropertyOwnerDto> Register(PropertyOwnerDto propertyOwnerDto); //Is like Create
    ResponseApi<PropertyOwnerDto> GetDetails(string vatNumber); //Is like Get(K id)
    ResponseApi<PropertyOwnerDto> Update(string vatNumber, PropertyOwnerDto propertyOwnerDto);
    ResponseApi<bool> Delete(string vatNumber);
}

