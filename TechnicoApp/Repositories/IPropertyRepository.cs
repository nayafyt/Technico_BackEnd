using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Models;

namespace TechnicoApp.Repositories;

public interface IPropertyRepository<T,K> where T : class

{
    Task<T?> DeactivateAsync(K id);
    Task<List<T>> GetByOwnerVatNumberAsync(string vatNumber);

    
}
