using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Models;

namespace TechnicoApp.Models;


/// <summary>
/// Represents a property item in the system, that is owned by a PropertyOwner.
/// </summary>
public class PropertyItem : IEntity<string>
{
    /// <summary>
    /// Gets or sets the unique id for the property item, which is mapped to the PropertyIdentificationNumber .
    /// </summary>
    public string Id { 
        get =>PropertyIdentificationNumber; 
        set=>PropertyIdentificationNumber =value; 
    }

    /// <summary>
    /// Gets or sets the PropertyIdenticationNumber of the property item. This serves as the unique identifier.
    /// </summary>
    public required string PropertyIdentificationNumber { get; set; }
    public string Address { get; set; } = string.Empty;
    public int YearOfConstruction { get; set; }
    public PropertyType PropertyType { get; set; }

    /// <summary>
    /// Gets or sets the PropertyOwnerVatNumber of the property item. 
    /// This serves as a foreign key linking to the property owner's VAT number.
    /// </summary>
    public required string PropertyOwnerVatNumber { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the property item is active. 
    /// Used as a soft-delete flag, defaulting to true (active).
    /// </summary>
    public bool IsActive { get; set; } = true;

}
