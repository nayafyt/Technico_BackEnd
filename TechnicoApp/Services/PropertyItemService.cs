using TechnicoApp.Domain.Interfaces;
using TechnicoApp.Domain.Models;

namespace TechnicoApp.Services;

public class PropertyItemService: IPropertyItemService
{
    private readonly IPropertyItemRepository _repository;

    public PropertyItemService(IPropertyItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<PropertyItem>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<PropertyItem?> GetByIdAsync(long id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CreateAsync(PropertyItem propertyItem)
    {
        await _repository.AddAsync(new PropertyItem
        {
            Id = propertyItem.Id,
            PropertyIdentificationNumber = propertyItem.PropertyIdentificationNumber,
            Address = propertyItem.Address,
            YearOfConstruction = propertyItem.YearOfConstruction,
            PropertyType= propertyItem.PropertyType,
            OwnerVAT = propertyItem.OwnerVAT,
        });



    }

    //public async Task UpdateAsync(PropertyItem propertyItem)
    //{
    //    await _repository.UpdateAsync(propertyItem);
    //}

    public async Task<PropertyItem?> DeletePermanentlyAsync(long id)
    {
        return await _repository.DeletePermanentlyAsync(id);
    }
    public async Task<PropertyItem?> DeactivateAsync(long id)
    {
        return await _repository.DeactivateAsync(id);
    }

}