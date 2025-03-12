using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.BasketDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServices.Models;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet("{id}")]
        public IActionResult GetBasketByMenuTableId(int id)
        {
            return Ok(_basketService.TGetBasketByMenuTableNumber(id));
        }
        [HttpGet("BasketListWithProductName/{id}")]
        public IActionResult BasketListWithProductName(int id)
        {
            var context = new Context();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select(z => new ResultBasketListWithProducts
            {
                BasketID = z.BasketID,
                ProductCount = z.ProductCount,
                MenuTableID = z.MenuTableID,
                ProductPrice = z.ProductPrice,
                ProductID = z.ProductID,
                TotalPrice = z.TotalPrice,
                ProductName = z.Product.ProductName
            }).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            var context = new Context();
            _basketService.TAdd(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                ProductCount = 1,
                MenuTableID = 5,
                ProductPrice = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                TotalPrice = 0,
            });
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetByID(id);
            _basketService.TDelete(value);
            return Ok("Sipariş Silindi.");
        }
    }
}
