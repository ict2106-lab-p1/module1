using Microsoft.AspNetCore.Http;

namespace LivingLab.Core.Interfaces.Services;

public interface IManualLogService
{
    void Process(IFormFile file);
    void Archive(int deviceId, DateTime start, DateTime end);
    void Archive(string deviceType, DateTime start, DateTime end);
}
