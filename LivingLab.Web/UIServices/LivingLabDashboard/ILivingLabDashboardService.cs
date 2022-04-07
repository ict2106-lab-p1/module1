namespace LivingLab.Web.UIServices.LivingLabDashboard;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILivingLabDashboardService
{
    Task<List<String>> GetUsages();
}
