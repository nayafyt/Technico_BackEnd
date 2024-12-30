using TechnicoApp.Domain.Interfaces;
using TechnicoApp.Domain.Models;
using TechnicoApp.Repositories;

namespace TechnicoApp.Services;

public class PropertyItemService: IPropertyItemService
{
    private readonly IRepository<PropertyItem, long> _repository;

    public PropertyItemService(IRepository<PropertyItem, long> repository)
    {
        _repository = repository;
    }



    public async Task<PropertyItem?> GetByIdAsync(long id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task CreateAsync(PropertyItem propertyItem)
    {
        await _repository.CreateAsync(new PropertyItem
        {
            Id = propertyItem.Id,
            PropertyIdentificationNumber = propertyItem.PropertyIdentificationNumber,
            Address = propertyItem.Address,
            YearOfConstruction = propertyItem.YearOfConstruction,
            PropertyType= propertyItem.PropertyType,
            PropertyOwnerVatNumber = propertyItem.PropertyOwnerVatNumber,
        });



    }

    //public async Task UpdateAsync(PropertyItem propertyItem)
    //{
    //    await _repository.UpdateAsync(propertyItem);
    //}

    public async Task<bool> DeletePermanentlyAsync(long id)
    {
        return await _repository.DeleteAsync(id);
    }
    public async Task<PropertyItem?> DeactivateAsync(long id)
    {
        return await _repository.DeactivateAsync(id);
    }

}