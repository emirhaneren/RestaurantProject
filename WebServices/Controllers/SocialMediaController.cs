using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.SocialMediaDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateSocialMediaDto> _validator;
        private readonly IValidator<UpdateSocialMediaDto> _validator2;
        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocailMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto socialMediaDto)
        {
            var validation = _validator.Validate(socialMediaDto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var value = _mapper.Map<SocialMedia>(socialMediaDto);
            _socialMediaService.TAdd(value);
            return Ok("Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(value);
            return Ok("Başarılı bir şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto socialMediaDto)
        {
            var validation = _validator2.Validate(socialMediaDto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var value = _mapper.Map<SocialMedia>(socialMediaDto);
            _socialMediaService.TUpdate(value);
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpGet("GetSocialMediaById/{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            return Ok(_mapper.Map<GetSocialMediaDto>(_socialMediaService.TGetByID(id)));
        }
    }
}
