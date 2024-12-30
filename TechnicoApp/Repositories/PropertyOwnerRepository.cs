using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicoApp.Repositories;

public class PropertyOwnerRepository: IRepository<PropertyOwner,string>
{
    private readonly TechnicoDbContext _context;

    public PropertyOwnerRepository(TechnicoDbContext context)
    {
        _context = context;
    }

    public async Task<List<PropertyOwner>> GetAllAsync()
    {
        return await _context.PropertyOwners
                    .Where(p => p.IsActive)
                    .ToListAsync();
    }

    public async Task<PropertyOwner?> GetByIdAsync(long id)
    {
        return await _context.PropertyOwners.FindAsync(id);

    }

    public async Task AddAsync(PropertyOwner PropertyOwner)
    {
        await _context.PropertyOwners.AddAsync(PropertyOwner);
        await _context.SaveChangesAsync();


    }

    public async Task<PropertyOwner?> UpdateAsync(PropertyOwner PropertyOwner)
    {
        _context.PropertyOwners.Update(PropertyOwner);
        await _context.SaveChangesAsync();
        return PropertyOwner;
    }

    public async Task<PropertyOwner> DeletePermanentlyAsync(long id)
    {
        var PropertyOwner = await _context.PropertyOwners.FindAsync(id);
        if (PropertyOwner != null)
        {
            _context.PropertyOwners.Remove(PropertyOwner);
            await _context.SaveChangesAsync();

        }
        return PropertyOwner;

    }
    public async Task<PropertyOwner?> DeactivateAsync(long id)
    {
        var PropertyOwner = await _context.PropertyOwners.FindAsync(id);
        {
            PropertyOwner.IsActive = false;
            _context.PropertyOwners.Update(PropertyOwner);
            await _context.SaveChangesAsync();
        }
        return PropertyOwner;
    }
}
