
using TechnicoApp.Domain.Models;
using TechnicoApp.Dtos;
using TechnicoApp.Models;

namespace TechnicoApp.Mappers;

/// <summary>
/// Implements the <see cref="IMapper{PropertyOwner, PropertyOwnerDto}"/> interface to convert between 
/// the <see cref="PropertyOwner"/> entity and the <see cref="PropertyOwnerDto"/>.
/// </summary>
public class PropertyItemMapper : IMapper<PropertyItem, PropertyItemDto>
{
    /// <summary>
    /// Converts a <see cref="PropertyOwner"/> entity into a <see cref="PropertyOwnerDto"/>.
    /// </summary>
    /// <param name="propertyOwner">The <see cref="PropertyOwner"/> entity to be converted.</param>
    /// <returns>A <see cref="PropertyOwnerDto"/> that represents the input <see cref="PropertyOwner"/> entity.</returns>
    public PropertyItemDto? GetDto(PropertyItem propertyItem)
    {
        if (propertyItem == null)
        {
            return null;
        }

        return new PropertyItemDto
        {
            PropertyIdentificationNumber = propertyItem.PropertyIdentificationNumber,
            Address = propertyItem.Address,
            YearOfConstruction= propertyItem.YearOfConstruction,
            PropertyType = propertyItem.PropertyType,
            PropertyOwnerVatNumber= propertyItem.PropertyOwnerVatNumber
        };
    }

    /// <summary>
    /// Converts a <see cref="PropertyOwnerDto"/> back into a <see cref="PropertyOwner"/> entity.    /// </summary>
    /// <param name="propertyOwnerDto">The <see cref="PropertyOwnerDto"/> to be converted.</param>
    /// <returns>A <see cref="PropertyOwner"/> entity that represents the input <see cref="PropertyOwnerDto"/>.</returns>
    public PropertyItem? GetModel(PropertyItemDto propertyItemDto)
    {
        if (propertyItemDto == null)
        {
            return null;
        }

        return new PropertyItem
        {

            PropertyIdentificationNumber = propertyItemDto.PropertyIdentificationNumber,
            Address = propertyItemDto.Address,
            YearOfConstruction = propertyItemDto.YearOfConstruction,
            PropertyType = propertyItemDto.PropertyType,
            PropertyOwnerVatNumber = propertyItemDto.PropertyOwnerVatNumber

        };
    }
}
