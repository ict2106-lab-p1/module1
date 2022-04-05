using Microsoft.AspNetCore.Http;

namespace LivingLab.Core.Interfaces.Services.CsvParser;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface ICsvParser<T>
{
    IEnumerable<T> Parse(IFormFile file);
}
