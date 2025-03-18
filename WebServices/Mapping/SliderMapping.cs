using AutoMapper;

namespace WebServices.Mapping
{
    public class SliderMapping :Profile
    {
        public SliderMapping()
        {
            CreateMap<EntityLayer.Entities.Slider, DtoLayer.SliderDto.ResultSliderDto>().ReverseMap();
            CreateMap<EntityLayer.Entities.Slider, DtoLayer.SliderDto.CreateSliderDto>().ReverseMap();
            CreateMap<EntityLayer.Entities.Slider, DtoLayer.SliderDto.UpdateSliderDto>().ReverseMap();
        }
    }
}
