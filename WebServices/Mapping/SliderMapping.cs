using AutoMapper;
using DtoLayer.SliderDto;
using EntityLayer.Entities;

namespace WebServices.Mapping
{
    public class SliderMapping :Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider,ResultSliderDto>().ReverseMap();
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();
        }
    }
}
