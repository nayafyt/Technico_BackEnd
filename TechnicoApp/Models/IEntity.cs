using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicoApp.Models;

/// <summary>
/// Defines a generic entity with an identifier of type <typeparamref name="K"/>.
/// </summary>
/// <typeparam name="K">The type of the identifier.</typeparam>
public interface IEntity<K>
{
    K Id { get; set; }
}
