using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Web.ViewModels;

namespace LivingLab.Web.UIServices.Device;

public class AccessoryServices : IAccessoryService
{
    private readonly IMapper _mapper;
    private readonly IAccessoryRepository _accessoryRepository;

    public AccessoryServices( IMapper mapper, IAccessoryRepository accessoryRepository)
    {
        _mapper = mapper;
        _accessoryRepository = accessoryRepository;
    }

    public async Task<ViewAccessoryViewModel> viewAccessory(string accessoryType)
    {
        //retrieve data from db
        List<Accessory> accessoryList = await _accessoryRepository.GetAccessoryWithAccessoryType(accessoryType);

        //map entity model to view model
        List<AccessoryViewModel> accessories = _mapper.Map<List<Accessory>, List<AccessoryViewModel>>(accessoryList);

        //add list of accessory view model to the view accessory view model
        ViewAccessoryViewModel viewAccessories = new ViewAccessoryViewModel();
        viewAccessories.AccessoryList = accessories;
        return viewAccessories;
    }
    
    public async Task<AccessoryTypeViewModel> viewAccessoryType()
    {
        List<Core.ViewAccessoryTypeDTO> viewAccessoryTypeDtos = await _accessoryRepository.GetAccessoryType();
        AccessoryTypeViewModel accessoryTypeViewModel = new AccessoryTypeViewModel();
        accessoryTypeViewModel.ViewAccessoryTypeDtos = viewAccessoryTypeDtos;
        return accessoryTypeViewModel;
    }
    
}
