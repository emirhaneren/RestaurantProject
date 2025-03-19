using BusinessLayer.Abstract;
using DtoLayer.MessageDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message()
            {
                Mail = createMessageDto.Mail,
                MessageContent = createMessageDto.MessageContent,
                NameSurname = createMessageDto.NameSurname,
                PhoneNumber = createMessageDto.PhoneNumber,
                SendDate = createMessageDto.SendDate,
                Status = false,
                Subject = createMessageDto.Subject
            };
            _messageService.TAdd(message);
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
            Message message = new Message()
            {
                MessageID = updateMessageDto.MessageID,
                Mail = updateMessageDto.Mail,
                MessageContent = updateMessageDto.MessageContent,
                NameSurname = updateMessageDto.NameSurname,
                PhoneNumber = updateMessageDto.PhoneNumber,
                SendDate = updateMessageDto.SendDate,
                Status = updateMessageDto.Status,
                Subject = updateMessageDto.Subject,
            };
            _messageService.TUpdate(message);
            return Ok("Başarılı şekilde güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            return Ok(value);
        }
    }
}
