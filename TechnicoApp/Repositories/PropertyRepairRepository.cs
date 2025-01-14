using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnicoApp.Context;
using TechnicoApp.Models;

namespace TechnicoApp.Repositories;

public class PropertyRepairRepository : IRepository<PropertyRepair, long>, IPropertyRepository<PropertyRepair,long>, IPropertyRepairRepository
{
    private readonly TechnicoDbContext _context;
    private readonly IRepository<PropertyItem, string> _propertyRepository;

    public PropertyRepairRepository(TechnicoDbContext context, IRepository<PropertyItem, string> propertyRepository)
    {
        _context = context;
        _propertyRepository = propertyRepository;
    }

    public async Task<PropertyRepair?> CreateAsync(PropertyRepair propertyRepair)
    {
        //Check if the PropertyOwner already exists
        var existingPropertyItem = await _context.PropertyItems
            .FirstOrDefaultAsync(pi => pi.PropertyIdentificationNumber == propertyRepair.PropertyItem.PropertyIdentificationNumber);
        if (existingPropertyItem != null)
        {
            // Attach the existing PropertyOwner to the context
            _context.Entry(existingPropertyItem).State = EntityState.Unchanged;

            // Link the existing PropertyOwner to the PropertyRepair
            propertyRepair.PropertyItem = existingPropertyItem;
        }
        await _context.PropertyRepairs.AddAsync(propertyRepair);
        await _context.SaveChangesAsync();
        return propertyRepair;
    }

    public async Task<PropertyRepair?> GetAsync(long id)
    {
        return await _context.PropertyRepairs
        .AsNoTracking()
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<PropertyRepair>> GetAsync()
    {
        return await _context.PropertyRepairs
            .Include(pr => pr.PropertyItem.PropertyIdentificationNumber)
            .ToListAsync();
    }

    public async Task<PropertyRepair?> UpdateAsync(PropertyRepair propertyRepair)
    {
        _context.PropertyRepairs.Update(propertyRepair);
        await _context.SaveChangesAsync();
        return propertyRepair;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var propertyRepair = await _context.PropertyRepairs.FindAsync(id);
        if (propertyRepair == null) return false;

        _context.PropertyRepairs.Remove(propertyRepair);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<PropertyRepair?> DeactivateAsync(long id)
    {
        var propertyRepair = await _context.PropertyRepairs.FindAsync(id);
        if (propertyRepair == null) return default;
        propertyRepair.IsActive = false;
        _context.PropertyRepairs.Update(propertyRepair);
        await _context.SaveChangesAsync();

        return propertyRepair;
    }

    public async Task<List<PropertyRepair>> GetByOwnerVatNumberAsync(string vatNumber)
    {
        return await _context.Set<PropertyRepair>()
           .Include(pr => pr.PropertyItem)
           .Where(item => item.PropertyItem != null && item.PropertyItem.PropertyOwnerVatNumber.Equals(vatNumber))
           .ToListAsync();
    }

    public async Task<List<PropertyRepair>> GetByDate(DateOnly date)
    {
        return await _context.Set<PropertyRepair>()
               .Where(item => DateOnly.FromDateTime(item.DateTime) == date)
               .ToListAsync();
    }

    public async Task<PropertyRepair?> GetAsync(string vatNumber, DateTime date)
    {
        return await _context.PropertyRepairs
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.DateTime == date && p.PropertyItem.PropertyOwnerVatNumber == vatNumber);
    }
}
