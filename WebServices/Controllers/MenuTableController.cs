using BusinessLayer.Abstract;
using DtoLayer.MenuTableDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTableController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }
        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }
        [HttpGet]
        public IActionResult MenuTableList()
        {
            return Ok(_menuTableService.TGetListAll());
        }
        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            MenuTable menuTable = new MenuTable
            {
                Name = createMenuTableDto.Name,
                Status = createMenuTableDto.Status
            };
            _menuTableService.TAdd(menuTable);
            return Ok("Masa Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetByID(id);
            _menuTableService.TDelete(value);
            return Ok("Masa Silindi");
        }
        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            MenuTable menuTable = new MenuTable
            {
                MenuTableID = updateMenuTableDto.MenuTableID,
                Name = updateMenuTableDto.Name,
                Status = updateMenuTableDto.Status
            };
            _menuTableService.TUpdate(menuTable);
            return Ok("Masa Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            return Ok(_menuTableService.TGetByID(id));
        }
    }
}
