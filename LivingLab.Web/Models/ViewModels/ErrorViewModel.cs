namespace LivingLab.Web.Models.ViewModels;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
