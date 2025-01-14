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
    public PropertyRepairDto? GetDto(PropertyRepair propertyRepair)
    {
        if (propertyRepair == null )
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
            PropertyItemDto = propertyRepair.PropertyItem != null ? new PropertyItemDto()
            {
                PropertyIdentificationNumber = propertyRepair.PropertyItem.PropertyIdentificationNumber,
                Address = propertyRepair.Address,
                YearOfConstruction = propertyRepair.PropertyItem.YearOfConstruction,
                PropertyType = propertyRepair.PropertyItem.PropertyType,
                PropertyOwnerVatNumber = propertyRepair.PropertyItem.PropertyOwnerVatNumber
            } : null
        };
    }
    public PropertyRepair? GetModel(PropertyRepairDto propertyRepairDto)
    {
        if (propertyRepairDto == null)
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
            PropertyItem = new PropertyItem()
            {
                PropertyIdentificationNumber = propertyRepairDto.PropertyItemDto.PropertyIdentificationNumber,
                Address = propertyRepairDto.PropertyItemDto.Address,
                YearOfConstruction = propertyRepairDto.PropertyItemDto.YearOfConstruction,
                PropertyType = propertyRepairDto.PropertyItemDto.PropertyType,
                PropertyOwnerVatNumber = propertyRepairDto.PropertyItemDto.PropertyOwnerVatNumber

            }

        };
    }
}
