using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicoApp.Repositories;

/// <summary>
/// A generic repository interface for managing entities of type <typeparamref name="T"/> with id of type <typeparamref name="K"/>.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
/// <typeparam name="K">The type of the entity's id.</typeparam>
public interface IRepository<T, K> where T : class
{
    Task<T?> CreateAsync(T t);
    Task<T?> GetAsync(K id);
    Task<List<T>> GetAsync(int pageCount, int pageSize);
    Task<T?> UpdateAsync(T t);
    Task<bool> DeleteAsync(K id);
    


}




