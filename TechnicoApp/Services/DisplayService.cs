
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Repositories;

namespace TechnicoApp.Services;

/// <summary>
/// Service for displaying information related to the current user, including
/// Property Owner details, Property Items, and Repairs.
/// </summary>
public class DisplayService
{
    private readonly IRepository<PropertyOwner, string> _propertyOwnerRepository;
    //private readonly IRepository<PropertyItem, int> _propertyItemRepository;
    //private readonly IRepository<Repair, int> _repairRepository;

    public DisplayService(
        IRepository<PropertyOwner, string> propertyOwnerRepository
        //IRepository<PropertyItem, int> propertyItemRepository,
        //IRepository<Repair, int> repairRepository
        )
    {
        _propertyOwnerRepository = propertyOwnerRepository;
        //_propertyItemRepository = propertyItemRepository;
        //_repairRepository = repairRepository;
    }

    /// <summary>
    /// Fetches the details of a PropertyOwner by their VAT number.
    /// </summary>
    public PropertyOwner? GetPropertyOwnerDetails(string vatNumber)
    {
        return _propertyOwnerRepository.Read(vatNumber);
    }


    //Not yet implemented Entities PropertyItem, Repair
    ///// <summary>
    ///// Fetches PropertyItems for the given PropertyOwner.
    ///// </summary>
    //public List<PropertyItem> GetPropertyItems(string vatNumber)
    //{
    //    return _propertyItemRepository.Read().FindAll(item => item.OwnerVatNumber == vatNumber);
    //}

    ///// <summary>
    ///// Fetches Repairs for the PropertyItems of the given PropertyOwner.
    ///// </summary>
    //public List<Repair> GetRepairs(string vatNumber)
    //{
    //    var propertyItems = GetPropertyItems(vatNumber);
    //    var propertyItemIds = new HashSet<int>(propertyItems.Select(item => item.Id));

    //    return _repairRepository.Read().FindAll(repair => propertyItemIds.Contains(repair.PropertyItemId));
    //}
}

