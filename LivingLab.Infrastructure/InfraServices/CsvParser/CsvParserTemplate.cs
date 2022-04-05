using System.Text;

using Microsoft.AspNetCore.Http;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace LivingLab.Infrastructure.InfraServices.CsvParser;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public abstract class CsvParserTemplate<T> where T : class
{
    public IEnumerable<T> Parse(IFormFile file)
    {
        var filePath = SaveFile(file);
        var result = ReadFile(filePath);
        return MapResult(result);    
    }
    
    protected abstract string SaveFile(IFormFile file);
    protected abstract ParallelQuery<CsvMappingResult<T>> ReadFile(string filePath);
    protected abstract IEnumerable<T> MapResult(ParallelQuery<CsvMappingResult<T>> result);
}
