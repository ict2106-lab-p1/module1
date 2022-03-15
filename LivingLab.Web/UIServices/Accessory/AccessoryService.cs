using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Accessory;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Web.Models.ViewModels.Accessory;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LivingLab.Web.UIServices.Accessory;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AccessoryServices : IAccessoryService
{
    private readonly IMapper _mapper;
    private readonly IAccessoryDomainService _accessoryDomainService;

    public AccessoryServices( IMapper mapper, IAccessoryDomainService accessoryDomainService)
    {
        _mapper = mapper;
        _accessoryDomainService = accessoryDomainService;
    }

    public async Task<ViewAccessoryViewModel> ViewAccessory(string accessoryType)
    {
        // retrieve all accessory from specific accessory type from db
        List<Core.Entities.Accessory> accessoryList = await _accessoryDomainService.ViewAccessory(accessoryType);
        // map entity model to view model
        List<AccessoryViewModel> accessories = _mapper.Map<List<Core.Entities.Accessory>, List<AccessoryViewModel>>(accessoryList);
        // retrieve distinct accessory type list from db
        List<Core.Entities.AccessoryType> accessoryTypeList = await _accessoryDomainService.GetAllAsyncAccessoryType();
        // map accessory to accesory type view model
        List<AccessoryTypeViewModel> accessoryTypeViewModelList = _mapper.Map<List<AccessoryType>, List<AccessoryTypeViewModel>>(accessoryTypeList);
        // retrieve last accessory record from db
        Core.Entities.Accessory accessory = await _accessoryDomainService.GetAccessoryLastRow();
        // map accessory to accessory view model
        AccessoryViewModel accessoryViewModel = _mapper.Map<Core.Entities.Accessory, AccessoryViewModel>(accessory);
        
        ViewAccessoryViewModel viewAccessoryViewModel = new ViewAccessoryViewModel();
        viewAccessoryViewModel.Id = accessoryViewModel.Id + 1;
        viewAccessoryViewModel.BorrowableList = new List<SelectListItem>();
        viewAccessoryViewModel.BorrowableList.Add(new SelectListItem {Text = "Yes", Value = "1"});
        viewAccessoryViewModel.BorrowableList.Add(new SelectListItem {Text = "No", Value = "0"});
        viewAccessoryViewModel.AccessoryTypeNameList = new List<SelectListItem>();
        foreach (var item in accessoryTypeViewModelList)
        {
            viewAccessoryViewModel.AccessoryTypeId = item.Id;
            viewAccessoryViewModel.AccessoryTypeNameList.Add(new SelectListItem
            {
                Text = item.Type, Value = Convert.ToString(item.Id)
            });
        }
        viewAccessoryViewModel.AccessoryTypeNameList.Add(new SelectListItem {Text = "Others", Value = "Others"});
        
        viewAccessoryViewModel.AccessoryList = accessories;
        return viewAccessoryViewModel;
    }

    public async Task<ViewAccessoryTypeViewModel> ViewAccessoryType()
    {
        List<ViewAccessoryTypeDTO> viewAccessoryTypeDtos = await _accessoryDomainService.ViewAccessoryType();
        List<OverallAccessoryTypeViewModel> accessoryTypeViewModels =
            _mapper.Map<List<ViewAccessoryTypeDTO>, List<OverallAccessoryTypeViewModel>>(viewAccessoryTypeDtos);
        return new ViewAccessoryTypeViewModel {accessoryTypeList = accessoryTypeViewModels};
    }

    public async Task<ViewAccessoryViewModel> AddAccessory(ViewAccessoryViewModel viewModelInput)
    {
        ViewAccessoryViewModel viewAccessoryViewModel = viewModelInput;
        AccessoryViewModel accessoryViewModel = new AccessoryViewModel();
        accessoryViewModel.AccessoryType = new AccessoryType();
        if (viewAccessoryViewModel.AccessoryTypeId == 0)
        {
            accessoryViewModel.AccessoryType.Name = viewAccessoryViewModel.Name;
            accessoryViewModel.AccessoryType.Type = viewAccessoryViewModel.newAccessoryType;
            accessoryViewModel.AccessoryType.Borrowable = viewAccessoryViewModel.BorrowableIndex == 1; // needa test
            accessoryViewModel.AccessoryType.Description = viewAccessoryViewModel.Description;
        }
        else
        {
            accessoryViewModel.AccessoryTypeId = viewAccessoryViewModel.AccessoryTypeId;
        }

        accessoryViewModel.Status = "Reviewing";
        accessoryViewModel.LastUpdated = DateTime.Now;
        accessoryViewModel.LabId = 1; // CURRENTLY HARDCODED NEEDA GET REAL ONE
        
        // map view model back to accessory
        Core.Entities.Accessory accessory = _mapper.Map<AccessoryViewModel, Core.Entities.Accessory>(accessoryViewModel);

        await _accessoryDomainService.AddAccessory(accessory);
        
        return viewModelInput;
    }
}
