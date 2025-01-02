using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Domain.Models;

namespace TechnicoApp.Repositories;

public interface IPropertyItemRepository
{
    Task<PropertyItem?> DeactivateAsync(long id);
    Task<List<PropertyItem>> GetByOwnerVatNumberAsync(string vatNumber);
}
