using TechnicoApp.Domain.Models;

namespace Technico.WebAPI.DTOs;

public class PropertyItemDTO
{
    public long Id { get; set; }
    public string PropertyIdentificationNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int YearOfConstruction { get; set; }
    public PropertyType PropertyType { get; set; }
    public string OwnerVAT { get; set; } = string.Empty;
}
