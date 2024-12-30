using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Dtos;

namespace TechnicoApp.Services;

/// <summary>
/// Defines the basic CRUD operations for a service that handles entities of type <typeparamref name="T"/> 
/// and their corresponding data transfer objects (DTO) of type <typeparamref name="D"/>. 
/// The operations include creating, reading, updating, and deleting entities, and returning responses wrapped in <see cref="ResponseApi{D}"/>.
/// </summary>
/// <typeparam name="T">The type of the entity that the service manages.</typeparam>
/// <typeparam name="D">The type of the data transfer object (DTO) that represents the entity for API communication.</typeparam>
/// <typeparam name="K">The type of the id of the entity.</typeparam>

public interface IService<T, D, K>
{
    ResponseApi<D> Create(T t);
    ResponseApi<D> Read(K id);
    ResponseApi<List<D>> Read();
    ResponseApi<D> Update(K id, T t);
    ResponseApi<bool> Delete(K id);
}
