namespace LivingLab.Core.Notifications;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface INotifier
{
    Task Notify(string message);
}
