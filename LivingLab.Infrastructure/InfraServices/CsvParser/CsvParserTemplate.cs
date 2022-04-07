
using Microsoft.AspNetCore.Http;

using TinyCsvParser.Mapping;

namespace LivingLab.Infrastructure.InfraServices.CsvParser;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public abstract class CsvParserTemplate<T> where T : class
{
    /// <summary>
    /// Parse a CSV file from HTTP request form-field into list of T objects
    /// </summary>
    /// <param name="file">CSV file</param>
    /// <returns>list of T</returns>
    public IEnumerable<T> Parse(IFormFile file)
    {
        var filePath = SaveFile(file);
        var result = ReadFile(filePath);
        return MapResult(result);
    }

    /// <summary>
    /// save file temporarily on disk
    /// </summary>
    /// <param name="file">CSV file</param>
    /// <returns>path to temporary location allocated by system</returns>
    protected abstract string SaveFile(IFormFile file);
    /// <summary>
    /// read CSV file from disk and interpret as iterable objects
    /// </summary>
    /// <param name="filePath">path to CSV file on disk</param>
    /// <returns>on-demand query that generates objects</returns>
    protected abstract ParallelQuery<CsvMappingResult<T>> ReadFile(string filePath);
    /// <summary>
    /// map all given CSV row objects to DTO T objects
    /// </summary>
    /// <param name="result">query that generates CSV row objects</param>
    /// <returns>iterable of DTO T objects</returns>
    protected abstract IEnumerable<T> MapResult(ParallelQuery<CsvMappingResult<T>> result);
}
