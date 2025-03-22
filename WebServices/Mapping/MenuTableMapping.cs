using AutoMapper;
using DtoLayer.MenuTableDto;
using EntityLayer.Entities;

namespace WebServices.Mapping
{
    public class MenuTableMapping:Profile
    {
        public MenuTableMapping()
        {
            CreateMap<MenuTable, ResultMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, GetMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, UpdateMenuTableDto>().ReverseMap();
            CreateMap<MenuTable, CreateMenuTableDto>().ReverseMap();
        }
    }
}
