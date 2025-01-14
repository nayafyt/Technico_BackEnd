using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Models;

namespace TechnicoApp.Repositories;

public interface IPropertyRepairRepository
{
    Task<List<PropertyRepair>> GetByDate (DateOnly date);
   Task<PropertyRepair?> GetAsync (string vatNumber,DateTime date);
    
}
