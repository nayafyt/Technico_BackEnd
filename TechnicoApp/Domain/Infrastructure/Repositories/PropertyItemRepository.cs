using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnicoApp.Domain.Context;
using TechnicoApp.Domain.Interfaces;
using TechnicoApp.Domain.Models;

namespace TechnicoApp.Domain.Infrastructure.Repositories;

public class PropertyItemRepository : IPropertyItemRepository
{
    private readonly TechnicoDbContext _context;

    public PropertyItemRepository(TechnicoDbContext context)
    {
        _context = context;
    }

    public async Task<List<PropertyItem>> GetAllAsync()
    {
        return await _context.PropertyItems
                    .Where(p => p.IsActive)
                    .ToListAsync();
    }

    public async Task<PropertyItem?> GetByIdAsync(long id)
    {
        return await _context.PropertyItems.FindAsync(id);

    }

    public async Task AddAsync(PropertyItem propertyItem)
    {
        await _context.PropertyItems.AddAsync(propertyItem);
        await _context.SaveChangesAsync();
        
        
    }

    public async Task<PropertyItem> UpdateAsync(PropertyItem propertyItem)
    {
        _context.PropertyItems.Update(propertyItem);
        await _context.SaveChangesAsync();
        return propertyItem;
    }

    public async Task<PropertyItem?> DeletePermanentlyAsync(long id)
    {
        var propertyItem = await _context.PropertyItems.FindAsync(id);
        if (propertyItem != null)
        {
            _context.PropertyItems.Remove(propertyItem);
            await _context.SaveChangesAsync();
            
        }
        return propertyItem;
       
    }
    public async Task<PropertyItem?> DeactivateAsync(long id)
    {
        var propertyItem = await _context.PropertyItems.FindAsync(id);
        {
            propertyItem.IsActive = false;
            _context.PropertyItems.Update(propertyItem);
            await _context.SaveChangesAsync();
        }
        return propertyItem;
    }

}

