using AutoMapper;

using LivingLab.Core.Entities.DTO;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Web.Models.ViewModels.Accessory;

namespace LivingLab.Web.UIServices.Accessory;

public class AccessoryServices : IAccessoryService
{
    private readonly IMapper _mapper;
    private readonly IAccessoryDomainService _accessoryDomainService;

    public AccessoryServices( IMapper mapper, IAccessoryDomainService accessoryDomainService)
    {
        _mapper = mapper;
        _accessoryDomainService = accessoryDomainService;
    }

    public async Task<ViewAccessoryViewModel> viewAccessory(string accessoryType)
    {
        //retrieve data from db
        List<Core.Entities.Accessory> accessoryList = await _accessoryDomainService.ViewAccessory(accessoryType);

        //map entity model to view model
        List<AccessoryViewModel> accessories = _mapper.Map<List<Core.Entities.Accessory>, List<AccessoryViewModel>>(accessoryList);

        //add list of accessory view model to the view accessory view model
        return new ViewAccessoryViewModel
        {
            AccessoryList = accessories
        };
    }
    
    public async Task<AccessoryTypeViewModel> viewAccessoryType()
    {
        List<ViewAccessoryTypeDTO> viewAccessoryTypeDtos = await _accessoryDomainService.ViewAccessoryType();
        return new AccessoryTypeViewModel
        {
            ViewAccessoryTypeDtos = viewAccessoryTypeDtos
        };
    }
    
}
