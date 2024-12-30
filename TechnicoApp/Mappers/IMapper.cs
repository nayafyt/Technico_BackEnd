using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicoApp.Mappers;

/// <summary>
/// Provides a contract for converting between the T entity/model and the Dto (D).
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
/// <typeparam name="D">The Dto type.</typeparam>
public interface IMapper<T, D>
{
    /// <summary>
    /// Converts an object of type T model to a type D DTO.
    /// </summary>
    /// <param name="t">The object of type <typeparamref name="T"/> to be converted.</param>
    /// <returns>A Dto of type <typeparamref name="D"/> that corresponds to the entity <typeparamref name="T"/>.</returns>
    D? GetDto(T t);

    /// <summary>
    /// Converts a <typeparamref name="D"/> DTO to an object of type <typeparamref name="T"/> (model/entity).
    /// This method is typically used to recreate the original entity object after data has been transferred or modified.
    /// </summary>
    /// <param name="d">The object of type <typeparamref name="D"/> to be converted.</param>
    /// <returns>An entity of type <typeparamref name="T"/> that corresponds to the input Dto <typeparamref name="D"/>.</returns>
    T? GetModel(D d);
}
