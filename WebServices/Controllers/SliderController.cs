using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.SliderDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateSliderDto> _validator;
        private readonly IValidator<UpdateSliderDto> _validator2;
        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SliderList()
        {
            var value = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            var validation = _validator.Validate(createSliderDto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var value =_mapper.Map<Slider>(createSliderDto);
            _sliderService.TAdd(value);
            return Ok("Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            _sliderService.TDelete(value);
            return Ok("Başarılı bir şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateSliderDto updateSliderDto)
        {
            var validation = _validator2.Validate(updateSliderDto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var value = _mapper.Map<Slider>(updateSliderDto);
            _sliderService.TUpdate(value);
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpGet("GetSliderById/{id}")]
        public IActionResult GetSlider(int id)
        {
            return Ok(_mapper.Map<GetSliderDto>(_sliderService.TGetByID(id)));
        }
    }
}
