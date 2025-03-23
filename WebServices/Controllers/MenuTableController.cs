using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.MenuTableDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateMenuTableDto> _validator;
        private readonly IValidator<UpdateMenuTableDto> _validator2;

        public MenuTableController(IMenuTableService menuTableService, IMapper mapper, IValidator<UpdateMenuTableDto> validator2, IValidator<CreateMenuTableDto> validator)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
            _validator2 = validator2;
            _validator = validator;
        }
        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }
        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values =_mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            createMenuTableDto.Status = false;
            var validation = _validator.Validate(createMenuTableDto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var value = _mapper.Map<MenuTable>(createMenuTableDto);
            _menuTableService.TAdd(value);
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
            var validation = _validator2.Validate(updateMenuTableDto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var value = _mapper.Map<MenuTable>(updateMenuTableDto);
            _menuTableService.TUpdate(value);
            return Ok("Masa Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            return Ok(_mapper.Map<GetMenuTableDto>(_menuTableService.TGetByID(id)));
        }
        [HttpGet("ChangeMenuTableStatusToTrue/{id}")]
        public IActionResult ChangeMenuTableStatusToTrue(int id)
        {
            _menuTableService.TChangeMenuTableStatusToTrue(id);
            return Ok("Masa durumu true yapıldı.");
        }
        [HttpGet("ChangeMenuTableStatusToFalse/{id}")]
        public IActionResult ChangeMenuTableStatusToFalse(int id)
        {
            _menuTableService.TChangeMenuTableStatusToFalse(id);
            return Ok("Masa durumu false yapıldı.");
        }
    }
}
