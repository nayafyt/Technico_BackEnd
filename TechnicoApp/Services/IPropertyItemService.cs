﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using TechnicoApp.Dtos;

namespace TechnicoApp.Domain.Interfaces;

public interface IPropertyItemService
{
    Task<ResponseApi<PropertyItemDto>> CreateAsync(PropertyItemDto propertyItemDto);
    Task<ResponseApi<PropertyItemDto>> GetByIdAsync(long id);
    Task<ResponseApi<List<PropertyItemDto>>> GetAllAsync();
    //Task UpdateAsync(PropertyItem propertyItem);
    Task<ResponseApi<bool>> DeletePermanentlyAsync(long id);
    Task<ResponseApi<PropertyItemDto>> DeactivateAsync(long id);   
}    
