namespace LivingLab.Core.Interfaces.Services;

using Microsoft.AspNetCore.Http;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface ICsvParser<T>
{
    IEnumerable<T> Parse(IFormFile file);
}
