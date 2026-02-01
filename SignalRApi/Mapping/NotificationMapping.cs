using AutoMapper;
using SignalR.DtoLayer.AboutDtos;
using SignalR.DtoLayer.NotificationDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {

            CreateMap<Notification, ResultNotificationDto>();
            CreateMap<Notification, GetNotificationDto>();

            CreateMap<CreateNotificationDto, Notification>();
            CreateMap<UpdateNotificationDto, Notification>();

        }

  
    }
}
