using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.MessageDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateMessageDto> _validator;
        public MessageController(IMessageService messageService, IMapper mapper, IValidator<CreateMessageDto> validator)
        {
            _messageService = messageService;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            return Ok(_mapper.Map<List<ResultMessageDto>>(_messageService.TGetListAll()));
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.Status = false;
            createMessageDto.SendDate = DateTime.Now;

            var validationResult = _validator.Validate(createMessageDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var value = _mapper.Map<Message>(createMessageDto);
            _messageService.TAdd(value);
            return Ok("Başarılı şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            _messageService.TDelete(value);
            return Ok("Başarılı şekilde silindi.");
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(value);
            return Ok("Başarılı şekilde güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            return Ok(_mapper.Map<GetMessageDto>(_messageService.TGetByID(id)));
        }
    }
}
