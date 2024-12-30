using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Dtos;

namespace TechnicoApp.Services;

public interface IPropertyOwnerService
{
    ResponseApi<PropertyOwnerDto> RegisterPropertyOwner(PropertyOwnerDto propertyOwnerDto);
    ResponseApi<PropertyOwnerDto> GetPropertyOwnerDetails(string vatNumber);
    ResponseApi<PropertyOwnerDto> UpdatePropertyOwner(string vatNumber, PropertyOwnerDto propertyOwnerDto);
    ResponseApi<bool> DeletePropertyOwner(string vatNumber);
}

