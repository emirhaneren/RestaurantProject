using AutoMapper;
using DtoLayer.NotificationDto;
using EntityLayer.Entities;

namespace WebServices.Mapping
{
    public class NotificationMapping:Profile
    {
        public NotificationMapping()
        {
            CreateMap<Notification,ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, GetNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
        }
    }
}
