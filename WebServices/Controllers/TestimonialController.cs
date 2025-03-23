using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.TestimonialDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTestimonialDto> _validator;
        private readonly IValidator<UpdateTestimonialDto> _validator2;
        public TestimonialController(ITestimonialService estimonialService, IMapper mapper, IValidator<UpdateTestimonialDto> validator2, IValidator<CreateTestimonialDto> validator)
        {
            _testimonialService = estimonialService;
            _mapper = mapper;
            _validator2 = validator2;
            _validator = validator;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            createTestimonialDto.Status = true;
            var validation = _validator.Validate(createTestimonialDto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var value = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(value);
            return Ok("Başarılı bir şekilde oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTesimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return Ok("Başarılı bir şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var validation = _validator2.Validate(updateTestimonialDto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(value);
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpGet("GetTestimonialById/{id}")]
        public IActionResult GetTestimonial(int id)
        {
            return Ok(_mapper.Map<GetTestimonialDto>(_testimonialService.TGetByID(id)));
        }
    }
}
