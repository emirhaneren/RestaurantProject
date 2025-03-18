using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DiscountDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
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
            _discountService.TAdd(new Discount()
            {
                Amount = createDiscountDto.Amount,
                DiscountDescription = createDiscountDto.DiscountDescription,
                DiscountTitle = createDiscountDto.DiscountTitle,
                ImageUrl = createDiscountDto.ImageUrl,
                Status = false
            });
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
            _discountService.TUpdate(new Discount()
            {
                DiscountID = updateDiscountDto.DiscountID,
                Amount = updateDiscountDto.Amount,
                DiscountDescription = updateDiscountDto.DiscountDescription,
                DiscountTitle = updateDiscountDto.DiscountTitle,
                ImageUrl = updateDiscountDto.ImageUrl,
                Status = updateDiscountDto.Status
            });
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpGet("GetDiscountById/{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            return Ok(value);
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
