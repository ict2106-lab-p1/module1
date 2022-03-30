using AutoMapper;

using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels.UserManagement;

namespace LivingLab.Web.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<ApplicationUser, UserManagementViewModel>();
        CreateMap<UserManagementViewModel, ApplicationUser>();
    }
}
