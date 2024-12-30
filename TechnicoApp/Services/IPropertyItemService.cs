using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Domain.Models;

namespace TechnicoApp.Domain.Interfaces;

public interface IPropertyItemService
{
    Task CreateAsync(PropertyItem propertyItem);
    Task<PropertyItem?> GetByIdAsync(long id);
    //Task<List<PropertyItem>> GetAllAsync();
    //Task UpdateAsync(PropertyItem propertyItem);
    Task<bool> DeletePermanentlyAsync(long id);
    Task<PropertyItem?> DeactivateAsync(long id);   
}
