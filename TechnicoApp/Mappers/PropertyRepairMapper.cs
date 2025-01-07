using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Dtos;
using TechnicoApp.Models;

namespace TechnicoApp.Mappers;

public class PropertyRepairMapper: IMapper<PropertyRepair, PropertyRepairDto>
{
    IMapper<PropertyOwner, PropertyOwnerDto> _mapperPropertyOwner;
    public PropertyRepairDto? GetDto(PropertyRepair propertyRepair)
    {
        if (propertyRepair == null || propertyRepair.PropertyOwner == null)
        {
                return null;
        }

        return new PropertyRepairDto
        {
            DateTime = propertyRepair.DateTime,
            RepairType = propertyRepair.RepairType,
            Description = propertyRepair.Description,
            Address = propertyRepair.Address,
            Status = propertyRepair.Status,
            Cost = propertyRepair.Cost,
            PropertyOwnerDto = _mapperPropertyOwner.GetDto(propertyRepair.PropertyOwner)
        };
    }
    public PropertyRepair? GetModel(PropertyRepairDto propertyRepairDto)
    {
        if (propertyRepairDto == null || propertyRepairDto.PropertyOwnerDto == null)
        {
            return null;
        }
        return new PropertyRepair
        {
            DateTime = propertyRepairDto.DateTime,
            RepairType = propertyRepairDto.RepairType,
            Description = propertyRepairDto.Description,
            Address = propertyRepairDto.Address,
            Status = propertyRepairDto.Status,
            Cost = propertyRepairDto.Cost,
            PropertyOwner = _mapperPropertyOwner.GetModel(propertyRepairDto.PropertyOwnerDto)

        };
    }
}
