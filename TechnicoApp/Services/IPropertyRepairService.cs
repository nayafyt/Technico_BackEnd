using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Dtos;

namespace TechnicoApp.Services;

public interface IPropertyRepairService
{
    Task<ResponseApi<PropertyRepairDto>> CreateAsync(PropertyRepairDto propertyRepairDto);
    Task<ResponseApi<List<PropertyRepairDto>>> SearchByUserVATNumber(string VATNumber);
    Task<ResponseApi<List<PropertyRepairDto>>> SearchByDate(DateOnly date);
    Task<ResponseApi<bool>> DeletePermanentlyAsync(long id);
    Task<ResponseApi<PropertyRepairDto>> DeactivateAsync(long id);

}
