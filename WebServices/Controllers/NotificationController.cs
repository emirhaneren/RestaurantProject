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

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("NotificationList")]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetListAll());
        }
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }
        [HttpGet("NotificationListByStatusFalse")]
        public IActionResult NotificationListByStatusFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByStatusFalse());
        }
        [HttpPost("CreateNotification")]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            Notification notification = new Notification()
            {
                Type = createNotificationDto.Type,
                Icon = createNotificationDto.Icon,
                Description = createNotificationDto.Description,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Status = false
            };
            _notificationService.TAdd(notification);
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
            return Ok(_notificationService.TGetByID(id));
        }
        [HttpPut("UpdateNotification/{id}")]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            Notification notification = new Notification()
            {
                NotificationID = updateNotificationDto.NotificationID,
                Type = updateNotificationDto.Type,
                Icon = updateNotificationDto.Icon,
                Description = updateNotificationDto.Description,
                Date = updateNotificationDto.Date,
                Status = updateNotificationDto.Status
            };
            _notificationService.TUpdate(notification);
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
