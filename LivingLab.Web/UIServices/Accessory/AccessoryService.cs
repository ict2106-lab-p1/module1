using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Accessory;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Web.Models.ViewModels.Accessory;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace LivingLab.Web.UIServices.Accessory;

/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AccessoryServices : IAccessoryService
{
    private readonly IMapper _mapper;
    private readonly IAccessoryDomainService _accessoryDomainService;

    public AccessoryServices(IMapper mapper, IAccessoryDomainService accessoryDomainService)
    {
        _mapper = mapper;
        _accessoryDomainService = accessoryDomainService;
    }

    public async Task<ViewAccessoryViewModel> ViewAccessory(string accessoryType)
    {
        // retrieve all accessory from specific accessory type from db
        List<Core.Entities.Accessory> accessoryList = await _accessoryDomainService.ViewAccessory(accessoryType);
        // map entity model to view model
        List<AccessoryViewModel> accessories =
            _mapper.Map<List<Core.Entities.Accessory>, List<AccessoryViewModel>>(accessoryList);
        return new ViewAccessoryViewModel {AccessoryList = accessories};
    }

    public async Task<ViewAccessoryTypeViewModel> ViewAccessoryType()
    {
        List<ViewAccessoryTypeDTO> viewAccessoryTypeDtos = await _accessoryDomainService.ViewAccessoryType();
        List<OverallAccessoryTypeViewModel> accessoryTypeViewModels =
            _mapper.Map<List<ViewAccessoryTypeDTO>, List<OverallAccessoryTypeViewModel>>(viewAccessoryTypeDtos);
        ViewAccessoryTypeViewModel viewAccessoryTypeViewModel = new ViewAccessoryTypeViewModel();
        return new ViewAccessoryTypeViewModel {accessoryTypeList = accessoryTypeViewModels};
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
        AccessoryDetailsViewModel accessoryVM =
            _mapper.Map<AccessoryDetailsDTO, AccessoryDetailsViewModel>(accessoryDetails);
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
        return new AccessoryDetailsViewModel {Accessory = accessory, AccessoryTypes = accessoryTypeList};
    }

    public async Task<ViewAccessoryViewModel> AddAccessory(AccessoryDetailsViewModel viewModelInput)
    {
        AccessoryDetailsViewModel addAccessoryDetails = viewModelInput;
        ViewAccessoryViewModel viewAccessoryViewModel = new ViewAccessoryViewModel();
        AccessoryViewModel accessoryVM = new AccessoryViewModel();
        // Add new accessory Type
        if (addAccessoryDetails.NewAccessoryType != null)
        {
            accessoryVM.AccessoryType = new AccessoryType();
            accessoryVM.AccessoryType.Name = addAccessoryDetails.Accessory.AccessoryType.Name;
            accessoryVM.AccessoryType.Type = addAccessoryDetails.NewAccessoryType;
            accessoryVM.AccessoryType.Description = addAccessoryDetails.Accessory.AccessoryType.Description;
            accessoryVM.AccessoryType.Borrowable = addAccessoryDetails.BorrowableValue == "1";
        }
        else
        {
            accessoryVM.AccessoryTypeId = addAccessoryDetails.Accessory.AccessoryType.Id;
        }

        accessoryVM.Status = "Reviewing";
        accessoryVM.LastUpdated = DateTime.Now;
        accessoryVM.LabId = 1; //currently hardcoded need get real one

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
