using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicoApp.Dtos;

/// <summary>
/// Represents the response structure returned by the API, containing the value of the response,
/// the status code, and an optional description of the response.
/// </summary>
/// <typeparam name="T">The type of the value returned by the API.</typeparam>
public class ResponseApi<T>
{
    public T? Value { get; set; }
    public int StatusCode { get; set; }
    public string? Description { get; set; }
}
