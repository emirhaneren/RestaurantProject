using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.AboutDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateAboutDto> _validator;
        public AboutController(IAboutService aboutService, IMapper mapper, IValidator<UpdateAboutDto> validator)
        {
            _aboutService = aboutService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var value =_mapper.Map<About>(createAboutDto);
            _aboutService.TAdd(value);
            return Ok("Başarılı şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            _aboutService.TDelete(value);
            return Ok("Başarılı şekilde silindi.");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var validationResult = _validator.Validate(updateAboutDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var value = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(value);
            return Ok("Başarılı şekilde güncellendi.");
        }
        [HttpGet("GetAboutById/{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            return Ok(_mapper.Map<GetAboutDto>(value));
        }
    }
}
