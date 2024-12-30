using TechnicoApp.Domain.Models;
using TechnicoApp.Models;

namespace Technico.WebAPI.DTOs;

public class PropertyItemDTO
{
    public long Id { get; set; }
    public string PropertyIdentificationNumber { get; set; } = string.Empty;
    public Address Address { get; set; } = new Address();
    public int YearOfConstruction { get; set; }
    public PropertyType PropertyType { get; set; }
    public string OwnerVAT { get; set; } = string.Empty;
}
