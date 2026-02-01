using AutoMapper;
using SignalRWebUI.Dtos.NotificationDtos;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Mapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {
            CreateMap<GetNotificationDto, NotificationViewModel>();
            CreateMap<NotificationViewModel, CreateNotificationDto>();
            CreateMap<NotificationViewModel, UpdateNotificationDto>();
        }
    }
}
