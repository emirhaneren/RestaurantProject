using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.SocialMediaDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
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
            _socialMediaService.TAdd(new SocialMedia()
            {
                Title = socialMediaDto.Title,
                Icon = socialMediaDto.Icon,
                Url = socialMediaDto.Url,
            });
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
            _socialMediaService.TUpdate(new SocialMedia()
            {
                Title = socialMediaDto.Title,
                Icon = socialMediaDto.Icon,
                Url = socialMediaDto.Url,
                SocialMediaID = socialMediaDto.SocialMediaID,
            });
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpGet("GetSocialMediaById/{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            return Ok(value);
        }
    }
}
