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
            PropertyOwnerDto = new PropertyOwnerDto() { 
                VatNumber = propertyRepair.PropertyOwner.VatNumber,
                Name = propertyRepair.PropertyOwner.Name,
                Surname = propertyRepair.PropertyOwner.Surname,
                Address = propertyRepair.PropertyOwner.Address,
                Password = propertyRepair.PropertyOwner.Password,
                PhoneNumber = propertyRepair.PropertyOwner.PhoneNumber,
                Email = propertyRepair.PropertyOwner.Email,
                UserType = propertyRepair.PropertyOwner.UserType
            }
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
            PropertyOwner = new PropertyOwner()
            {
                VatNumber = propertyRepairDto.PropertyOwnerDto.VatNumber,
                Name = propertyRepairDto.PropertyOwnerDto.Name,
                Surname = propertyRepairDto.PropertyOwnerDto.Surname,
                PhoneNumber = propertyRepairDto.PropertyOwnerDto.PhoneNumber,
                Address = propertyRepairDto.PropertyOwnerDto.Address,
                Email = propertyRepairDto.PropertyOwnerDto.Email,
                Password = propertyRepairDto.PropertyOwnerDto.Password,
                UserType = propertyRepairDto.PropertyOwnerDto.UserType
            }

        };
    }
}
