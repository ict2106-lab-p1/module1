using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Repositories;

public interface ILabAccessRepository : IRepository<LabAccess>
{
    Task<LabAccess?> GetInvalidLabAccess(string userId, string initiatorId);
    Task<List<LabAccess>?> GetAllInvalidLabAccess();
    Task<LabAccess?> AddInvalidLabAccess(LabAccess entry);
    Task<int> DeleteInvalidLabAccess(string userId, string labId);
}
