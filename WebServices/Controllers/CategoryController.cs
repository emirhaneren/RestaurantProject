using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.BookingDto;
using DtoLayer.CategoryDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCategoryDto> _validator;
        private readonly IValidator<UpdateCategoryDto> _validator2;
        public CategoryController(ICategoryService categoryService, IMapper mapper, IValidator<CreateCategoryDto> validator, IValidator<UpdateCategoryDto> validator2)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _validator = validator;
            _validator2 = validator2;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            createCategoryDto.CategoryStatus = true;
            var validation=_validator.Validate(createCategoryDto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var value = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(value);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            _categoryService.TDelete(value);
            return Ok("Başarılı bir şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var validation = _validator2.Validate(updateCategoryDto);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var value = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(value);
            return Ok("Başarılı bir şekilde güncellendi");
        }
        [HttpGet("GetCategoryById/{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            return Ok(_mapper.Map<GetCategoryDto>(value));
        }
        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            return Ok(_categoryService.TCategoryCount());
        }

        [HttpGet("GetActiveCategoryCount")]
        public IActionResult GetActiveCategoryCount()
        {
            return Ok(_categoryService.TActiveCategoryCount());
        }
        [HttpGet("GetPassiveCategoryCount")]
        public IActionResult GetPassiveCategoryCount()
        {
            return Ok(_categoryService.TPassiveCategoryCount());
        }
    }
}
