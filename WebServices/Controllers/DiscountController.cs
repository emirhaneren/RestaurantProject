using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DiscountDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDiscountDto> _validator;
        private readonly IValidator<UpdateDiscountDto> _validator2;
        public DiscountController(IDiscountService discountService, IMapper mapper, IValidator<UpdateDiscountDto> validator2, IValidator<CreateDiscountDto> validator)
        {
            _discountService = discountService;
            _mapper = mapper;
            _validator2 = validator2;
            _validator = validator;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            createDiscountDto.Status = false;
            var validation = _validator.Validate(createDiscountDto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var value =_mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(value);
            return Ok("Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            _discountService.TDelete(value);
            return Ok("Başarılı bir şekilde islindi");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var validation = _validator2.Validate(updateDiscountDto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var value =_mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(value);
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpGet("GetDiscountById/{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            return Ok(_mapper.Map<GetDiscountDto>(value));
        }
        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            _discountService.TChangeStatus(id);
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpGet("GetActiveDiscounts")]
        public IActionResult GetActiveDiscounts()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetActiveDiscounts());
            return Ok(value);
        }
    }
}
