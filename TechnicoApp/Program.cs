using TechnicoApp.Dtos;
using TechnicoApp.Models;
using TechnicoApp.Repositories;
using TechnicoApp.Services;

// Create memory repository -to check PropertyOwner
var mockRepository = new MemoryRepository<PropertyOwner, string>();

IPropertyOwnerService propertyOwnerService = new PropertyOwnerService(mockRepository);

// Create some test data (PropertyOwnerDto)
var newOwner = new PropertyOwnerDto
{
    VatNumber = "123456789",
    Name = "John",
    Surname = "Doe",
    Address = new Address() { 
        Street = "Diamantopoulou 22",
        City = "Athens",
        PostalCode = "12345",
        Country = "Greece"
    },
    PhoneNumber = "555-1234",
    Email = "john.doe@example.com",
    Password = "password123",
    UserType = UserType.User
};

// Register a new Property Owner
var registerResponse = propertyOwnerService.Register(newOwner);
Console.WriteLine(registerResponse.Description);

// Retrieve Property Owner details by Id
// We assume Id is 1 after registration (mocked logic, this might be adjusted based on actual ID generation)
var getResponse = propertyOwnerService.GetDetails("123456789");
Console.WriteLine($"Get Response: {getResponse.Value.PhoneNumber}");
if (getResponse.StatusCode == 200)
{
    var ownerDetails = getResponse.Value;
    Console.WriteLine($"Owner Name: {ownerDetails.Name} {ownerDetails.Surname}");
}

// Update Property Owner details
var updatedOwner = new PropertyOwnerDto
{
    VatNumber = "123456789",
    Name = "John",
    Surname = "Doe",
    Address = new Address()
    {
        Street = "Diamantopoulou 22",
        City = "Athens",
        PostalCode = "12345",
        Country = "Greece"
    },
    PhoneNumber = "555-128900004",
    Email = "john.doe@example.com",
    Password = "password123",
    UserType = UserType.User
};

var updateResponse = propertyOwnerService.Update("123456789", updatedOwner);
Console.WriteLine(updateResponse.Description);
var getResponseAfterUpdate = propertyOwnerService.GetDetails("123456789");
Console.WriteLine($"Get Response After Update: {getResponseAfterUpdate.Value.PhoneNumber}");
// Delete Property Owner
var deleteResponse = propertyOwnerService.Delete("123456789");
Console.WriteLine(deleteResponse.Description);

// Try getting the deleted property owner (should return not found)
var getAfterDeleteResponse = propertyOwnerService.GetDetails("123456789");
Console.WriteLine(getAfterDeleteResponse.Description);

