using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnicoApp.Context;
using TechnicoApp.Models;


namespace TechnicoApp.Repositories;

public class PropertyItemRepository : IRepository<PropertyItem, string>, IPropertyRepository<PropertyItem, string>
{
    private readonly TechnicoDbContext _context;


    public async Task<PropertyItem?> CreateAsync(PropertyItem propertyItem)
    {
        // Check if the PropertyOwner already exists
        var existingPropertyOwner = await _context.PropertyOwners
            .FirstOrDefaultAsync(po => po.VatNumber == propertyItem.PropertyOwnerVatNumber);

        if (existingPropertyOwner == null)
        {
            return default;
        }
        await _context.PropertyItems.AddAsync(propertyItem);
        await _context.SaveChangesAsync();
        return propertyItem;

    }
    public async Task<PropertyItem?> GetAsync(string id)
    {
        return await _context.PropertyItems.FindAsync(id);

    }
    public PropertyItemRepository(TechnicoDbContext context)
    {
        _context = context;
    }

    public async Task<List<PropertyItem>> GetAsync()
    {
        return await _context.PropertyItems
                    .AsNoTracking()
                    .Where(p => p.IsActive)
                    .ToListAsync();
    }

    public async Task<PropertyItem?> UpdateAsync(PropertyItem propertyItem)
    {
        _context.PropertyItems.Update(propertyItem);
        await _context.SaveChangesAsync();
        return propertyItem;
    }

    public async Task<bool> DeleteAsync(string id)
    {

        var propertyItem = await _context.PropertyItems.FindAsync(id);
        if (propertyItem == null) return false;
        _context.PropertyItems.Remove(propertyItem);
        await _context.SaveChangesAsync();
        return true;       
    }

    public async Task<PropertyItem?> DeactivateAsync(string id)
    {
        var propertyItem = await _context.PropertyItems.FindAsync(id);
        if (propertyItem == null) return default;
        propertyItem.IsActive = false;
        _context.PropertyItems.Update(propertyItem);
        await _context.SaveChangesAsync();
        
        return propertyItem;
    }

    public async Task<List<PropertyItem>> GetByOwnerVatNumberAsync(string vatNumber)
    {
        return await _context.Set<PropertyItem>()
            .Where(item => item.PropertyOwnerVatNumber == vatNumber)
            .ToListAsync();
    }

    public async Task<List<PropertyItem>> GetAsync(int pageCount, int pageSize)
    {
        return await _context.PropertyItems
                    .AsNoTracking()
                    .Skip((pageCount-1)*pageSize)
                    .Take(pageSize)
                    .Where(p => p.IsActive)
                    .ToListAsync();
    }
}

