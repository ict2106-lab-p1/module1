namespace LivingLab.Core.Interfaces.Services;

using Microsoft.AspNetCore.Http;

public interface ICsvParser<T>
{
    IEnumerable<T> Parse(IFormFile file);
}
