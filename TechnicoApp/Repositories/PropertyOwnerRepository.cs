using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnicoApp.Context;
using TechnicoApp.Domain.Models;

namespace TechnicoApp.Repositories;

public class PropertyOwnerRepository : IRepository<PropertyOwner, string>
{
    private readonly TechnicoDbContext _context;

    public PropertyOwnerRepository(TechnicoDbContext context)
    {
        _context = context;
    }
    public async Task<PropertyOwner?> CreateAsync(PropertyOwner propertyOwner)
    {
        await _context.PropertyOwners.AddAsync(propertyOwner);
        await _context.SaveChangesAsync();
        return propertyOwner;
    }

    public async Task<PropertyOwner?> GetAsync(string vatNumber)
    {
        return await _context.PropertyOwners
        .AsNoTracking()
        .FirstOrDefaultAsync(p => p.VatNumber == vatNumber);
    }

    public async Task<List<PropertyOwner>> GetAsync()
    {
        return await _context.PropertyOwners.ToListAsync();
    }

    public async Task<PropertyOwner?> UpdateAsync(PropertyOwner propertyOwner)
    {
        _context.PropertyOwners.Update(propertyOwner);
        await _context.SaveChangesAsync();
        return propertyOwner;
    }

    public async Task<bool> DeleteAsync(string vatNumber)
    {
        if (string.IsNullOrEmpty(vatNumber))
            return false;

        var propertyOwner = await _context.PropertyOwners.FindAsync(vatNumber);
        if (propertyOwner == null) return false;

        _context.PropertyOwners.Remove(propertyOwner);
        await _context.SaveChangesAsync();
        return true;
    }


}
