using AutoMapper;

using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Web.Models.ViewModels.Accessory;

namespace LivingLab.Web.UIServices.Accessory;

public class AccessoryServices : IAccessoryService
{
    private readonly IMapper _mapper;
    private readonly IAccessoryRepository _accessoryRepository;

    public AccessoryServices( IMapper mapper, IAccessoryRepository accessoryRepository)
    {
        _mapper = mapper;
        _accessoryRepository = accessoryRepository;
    }

    public async Task<ViewAccessoryViewModel> viewAccessory()
    {
        //retrieve data from db
        List<Core.Entities.Accessory> accessoryList = await _accessoryRepository.GetAccessoryWithAccessoryType();

        //map entity model to view model
        List<AccessoryViewModel> accessories = _mapper.Map<List<Core.Entities.Accessory>, List<AccessoryViewModel>>(accessoryList);

        //add list of accessory view model to the view accessory view model
        ViewAccessoryViewModel viewAccessories = new ViewAccessoryViewModel();
        viewAccessories.AccessoryList = accessories;
        return viewAccessories;
    }
    
}
