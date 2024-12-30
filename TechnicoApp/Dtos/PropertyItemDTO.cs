using TechnicoApp.Domain.Models;
using TechnicoApp.Models;

namespace TechnicoApp.Dtos;

public class PropertyItemDto
{
    public long PropertyIdentificationNumber { get; set; }
    public string Address { get; set; } =string.Empty;
    public int YearOfConstruction { get; set; }
    public PropertyType PropertyType { get; set; }
    public string PropertyOwnerVatNumber { get; set; } = string.Empty;
}
