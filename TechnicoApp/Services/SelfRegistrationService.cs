using TechnicoApp.Dtos;
using TechnicoApp.Models;
using TechnicoApp.Repositories;
using TechnicoApp.Mappers;

public class SelfRegistrationService
{
    private readonly IRepository<PropertyOwner, string> _repository;
    private readonly IMapper<PropertyOwner, PropertyOwnerDto> _mapper;

    public SelfRegistrationService(IRepository<PropertyOwner, string> repository)
    {
        _repository = repository;
        _mapper = new PropertyOwnerMapper();
    }

    public ResponseApi<PropertyOwnerDto> Register(PropertyOwnerDto propertyOwnerDto)
    {
        var propertyOwner = _mapper.GetModel(propertyOwnerDto);
        if (propertyOwner == null)
        {
            return new ResponseApi<PropertyOwnerDto>
            {
                StatusCode = 400,
                Description = "Invalid data provided."
            };
        }

        var createdPropertyOwner = _repository.Create(propertyOwner);
        var propertyOwnerDtoResponse = _mapper.GetDto(createdPropertyOwner);

        return new ResponseApi<PropertyOwnerDto>
        {
            Value = propertyOwnerDtoResponse,
            StatusCode = 200,
            Description = "PropertyOwner successfully created."
        };
    }

}
