using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Domain.Models;

namespace TechnicoApp.Domain.Interfaces;

public interface IPropertyItemRepository
{
    Task<List<PropertyItem>> GetAllAsync();
    Task<PropertyItem?> GetByIdAsync(long id);
    Task AddAsync(PropertyItem propertyItem);
    Task<PropertyItem> UpdateAsync(PropertyItem propertyItem);
    Task<PropertyItem?> DeletePermanentlyAsync(long id);
    Task<PropertyItem?> DeactivateAsync(long id);

}
