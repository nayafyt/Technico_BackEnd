﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicoApp.Models;

namespace TechnicoApp.Dtos;

public class PropertyRepairDto
{
    public long Id { get; set; }
    public DateTime DateTime { get; set; }
    public RepairType RepairType { get; set; }
    public string? Description { get; set; }
    public string Address { get; set; } = string.Empty;
    public StatusType Status { get; set; } = 0;
    public decimal Cost { get; set; }
    public required PropertyItemDto PropertyItemDto { get; set; }
}
