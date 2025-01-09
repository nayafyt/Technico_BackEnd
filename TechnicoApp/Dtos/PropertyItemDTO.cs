using TechnicoApp.Models;

namespace TechnicoApp.Dtos;

public class PropertyItemDto
{
    public required string PropertyIdentificationNumber { get; set; }
    public string Address { get; set; } =string.Empty;
    public int YearOfConstruction { get; set; }
    public PropertyType PropertyType { get; set; }
    public required string PropertyOwnerVatNumber { get; set; }  
}
