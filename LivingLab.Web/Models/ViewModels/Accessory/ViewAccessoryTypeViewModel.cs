using LivingLab.Core.Entities.DTO;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace LivingLab.Web.Models.ViewModels.Accessory;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class ViewAccessoryTypeViewModel
{
    public string labLocation { get; set; }
    public List<OverallAccessoryTypeViewModel> accessoryTypeList { get; set; }
}
