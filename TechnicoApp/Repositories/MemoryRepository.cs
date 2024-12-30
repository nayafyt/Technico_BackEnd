using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Models;

namespace TechnicoApp.Repositories;

/// <summary>
/// A generic in-memory repository (using a List) for managing entities.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
/// <typeparam name="K">The type of the entity's id.</typeparam>
public class MemoryRepository<T, K>
    where T : IEntity<K>
{
    private List<T> _ts = [];

    public T Create(T t)
    {
        _ts.Add(t);
        return t;
    }

    public List<T> Read()
    {
        return _ts;
    }

    public T? Read(K id)
    {
        if (id == null) return default;
        return _ts.FirstOrDefault(t => id.Equals(t.Id));
    }

    public T? Update(K id, T t)
    {
        if (id == null) return default;

        T? existing = _ts.FirstOrDefault(t => id.Equals(t.Id));
        if (existing == null) return default;

        var index = _ts.IndexOf(existing);
        _ts[index] = t;
        return t;
    }

    public bool Delete(K id)
    {
        if (id == null) return false;
        T? t = _ts.FirstOrDefault(t => id.Equals(t.Id));
        if (t == null) return false;
        _ts.Remove(t);
        return true;
    }

}

