using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Models;

namespace TechnicoApp.Domain.Models;

public class PropertyItem: IEntity<long>
{
    public long Id { get; set; } // Primary Key
    public string PropertyIdentificationNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int YearOfConstruction { get; set; }
    public PropertyType PropertyType { get; set; }

    public string PropertyOwnerVatNumber { get; set; } = string.Empty; //foreign key

    // Soft-delete flag
    public bool IsActive { get; set; } = true; // Default to active

}
