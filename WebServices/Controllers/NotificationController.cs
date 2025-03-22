using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.NotificationDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet("NotificationList")]
        public IActionResult NotificationList()
        {
            return Ok(_mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetListAll()));
        }
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_mapper.Map<List<ResultNotificationDto>>(_notificationService.TNotificationCountByStatusFalse()));
        }
        [HttpGet("NotificationListByStatusFalse")]
        public IActionResult NotificationListByStatusFalse()
        {
            return Ok(_mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetAllNotificationByStatusFalse()));
        }
        [HttpPost("CreateNotification")]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            createNotificationDto.Status = false;
            createNotificationDto.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var value = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TAdd(value);
            return Ok("Bildirim Eklendi");
        }
        [HttpDelete("DeleteNotification/{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim Silindi");
        }
        [HttpGet("GetNotification/{id}")]
        public IActionResult GetNotification(int id)
        {
            return Ok(_mapper.Map<List<GetNotificationDto>>(_notificationService.TGetByID(id)));
        }
        [HttpPut("UpdateNotification/{id}")]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var value = _mapper.Map<Notification>(updateNotificationDto);
            _notificationService.TUpdate(value);
            return Ok("Bildirim Güncellendi");
        }
        [HttpGet("UpdateNotificationStatus/{id}")]
        public IActionResult UpdateNotificationStatus(int id)
        {
            _notificationService.TUpdateStatus(id);
            return Ok("Bildirim Durumu Güncellendi");
        }
    }
}
