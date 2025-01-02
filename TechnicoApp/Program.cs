using System.Xml.Linq;
using TechnicoApp.Context;
using TechnicoApp.Domain.Models;

Console.WriteLine($"""
        Technico -  AccentureXCodeHub Project
        Christina Galani
        Maria Moutousi 
        Angelos Osf
        Naya Fytali
        """);

PropertyItem propertyItem = new PropertyItem()
{
    PropertyIdentificationNumber = 1,
    YearOfConstruction = 2000,
    Address = "MariasPIs",
    PropertyOwnerVatNumber = "987654321",
    IsActive = true,
    PropertyType = 0
};

TechnicoDbContext _context = new TechnicoDbContext();
_context.Add(propertyItem);
_context.SaveChanges();
