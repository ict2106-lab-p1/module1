using AutoMapper;

using LivingLab.Core.DomainServices.Account;
using LivingLab.Core.DomainServices.Equipment.Accessory;
using LivingLab.Core.DomainServices.Lab;
using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Accessory;
using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels.Accessory;
using LivingLab.Web.Models.ViewModels.UserManagement;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace LivingLab.Web.UIServices.Accessory;

/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AccessoryService : IAccessoryService
{
    private readonly IMapper _mapper;
    private readonly IAccessoryDomainService _accessoryDomainService;
    private readonly IAccountDomainService _accountDomainService;
    private readonly ILabProfileDomainService _labProfileDomainService;
    public AccessoryService(IMapper mapper, IAccessoryDomainService accessoryDomainService, IAccountDomainService accountDomainService, ILabProfileDomainService labProfileDomainService)
    {
        _mapper = mapper;
        _accessoryDomainService = accessoryDomainService;
        _accountDomainService = accountDomainService;
        _labProfileDomainService = labProfileDomainService;
    }

    public async Task<ViewAccessoryViewModel> ViewAccessory(string accessoryType, string labLocation)
    {
        // retrieve all accessory from specific accessory type from db
        List<Core.Entities.Accessory> accessoryList = await _accessoryDomainService.ViewAccessory(accessoryType, labLocation);
        // map entity model to view model
        List<AccessoryViewModel> accessories =
            _mapper.Map<List<Core.Entities.Accessory>, List<AccessoryViewModel>>(accessoryList);
        return new ViewAccessoryViewModel {AccessoryList = accessories};
    }

    public async Task<ViewAccessoryTypeViewModel> ViewAccessoryType(string labLocation)
    {
        List<ViewAccessoryTypeDTO> viewAccessoryTypeDtos = await _accessoryDomainService.ViewAccessoryType(labLocation);
        List<OverallAccessoryTypeViewModel> accessoryTypeViewModels =
            _mapper.Map<List<ViewAccessoryTypeDTO>, List<OverallAccessoryTypeViewModel>>(viewAccessoryTypeDtos);
        return new ViewAccessoryTypeViewModel {accessoryTypeList = accessoryTypeViewModels, labLocation = labLocation};
    }

    public async Task<AccessoryViewModel> GetAccessory(int id)
    {
        Core.Entities.Accessory accessory = await _accessoryDomainService.GetAccessory(id);
        AccessoryViewModel accessoryViewModel = _mapper.Map<Core.Entities.Accessory, AccessoryViewModel>(accessory);
        return accessoryViewModel;
    }

    public async Task<AccessoryDetailsViewModel> AddAccessoryDetails()
    {
        //retrieve data from db
        AccessoryDetailsDTO accessoryDetails = await _accessoryDomainService.AddAccessoryDetails();
        AccessoryViewModel accessory =
            _mapper.Map<Core.Entities.Accessory, AccessoryViewModel>(accessoryDetails.Accessory);
        List<AccessoryTypeViewModel> accessoryTypeList =
            _mapper.Map<List<Core.Entities.AccessoryType>, List<AccessoryTypeViewModel>>(
                accessoryDetails.AccessoryTypes);

        return new AccessoryDetailsViewModel {Accessory = accessory, AccessoryTypes = accessoryTypeList};
    }

    public async Task<AccessoryDetailsViewModel> EditAccessoryDetails(int id)
    {
        //retrieve data from db
        AccessoryDetailsDTO accessoryDetails = await _accessoryDomainService.EditAccessoryDetails(id);
        AccessoryViewModel accessory =
            _mapper.Map<Core.Entities.Accessory, AccessoryViewModel>(accessoryDetails.Accessory);
        List<AccessoryTypeViewModel> accessoryTypeList =
            _mapper.Map<List<Core.Entities.AccessoryType>, List<AccessoryTypeViewModel>>(
                accessoryDetails.AccessoryTypes);
        AccessoryDetailsViewModel accessoryVM =
            _mapper.Map<AccessoryDetailsDTO, AccessoryDetailsViewModel>(accessoryDetails);
        var labUserListDB = await _accountDomainService.ViewAccounts();
        List<UserManagementViewModel> userList =
            _mapper.Map<List<ApplicationUser>, List<UserManagementViewModel>>(labUserListDB);
        return new AccessoryDetailsViewModel {Accessory = accessory, AccessoryTypes = accessoryTypeList, UserList = userList};
    }

    public async Task<ViewAccessoryViewModel> AddAccessory(AccessoryDetailsViewModel viewModelInput)
    {
        AccessoryDetailsViewModel addAccessoryDetails = viewModelInput;
        ViewAccessoryViewModel viewAccessoryViewModel = new ViewAccessoryViewModel();
        AccessoryViewModel accessoryVM = new AccessoryViewModel();

        var lab = await _labProfileDomainService.GetLabProfileDetails(viewModelInput.Accessory.Lab.LabLocation);
        accessoryVM.LabId = lab.LabId;
        // Add new accessory Type
        if (addAccessoryDetails.NewAccessoryType != null)
        {
            accessoryVM.AccessoryType = new AccessoryType();
            accessoryVM.AccessoryType.Type = addAccessoryDetails.NewAccessoryType;
            accessoryVM.AccessoryType.Description = addAccessoryDetails.Accessory.AccessoryType.Description;
            accessoryVM.AccessoryType.Borrowable = addAccessoryDetails.BorrowableValue == "1";
        }
        else
        {
            accessoryVM.AccessoryTypeId = addAccessoryDetails.Accessory.AccessoryType.Id;
        }
        accessoryVM.Name = addAccessoryDetails.Accessory.Name;
        accessoryVM.Status = "Available";
        accessoryVM.LastUpdated = DateTime.Today;
        accessoryVM.ReviewStatus = "Pending";
        
        // map view model back to accessory
        Core.Entities.Accessory newAccessory = _mapper.Map<AccessoryViewModel, Core.Entities.Accessory>(accessoryVM);
        // add new accessory to db
        await _accessoryDomainService.AddAccessory(newAccessory);

        return viewAccessoryViewModel;
    }

    public async Task<AccessoryDetailsViewModel> EditAccessory(AccessoryDetailsViewModel viewModelInput)
    {
        AccessoryDetailsDTO accessoryDetailsDto =
            _mapper.Map<AccessoryDetailsViewModel, AccessoryDetailsDTO>(viewModelInput);
        await _accessoryDomainService.EditAccessory(accessoryDetailsDto);
        return viewModelInput;
    }

    public async Task<AccessoryViewModel> DeleteAccessory(AccessoryViewModel deleteAccessory)
    {
        //retrieve data from db
        Core.Entities.Accessory accessory = _mapper.Map<AccessoryViewModel, Core.Entities.Accessory>(deleteAccessory);
        await _accessoryDomainService.DeleteAccessory(accessory);

        return deleteAccessory;
    }
}
