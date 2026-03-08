using AutoMapper;
using SignalRWebUI.Dtos.NotificationDtos;
using SignalRWebUI.ViewModels.NotificationViewModels;

namespace SignalRWebUI.Mapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {
            CreateMap<ResultNotificationDto, ResultNotificationViewModel>();
            CreateMap<GetNotificationDto, UpdateNotificationViewModel>();
            CreateMap<CreateNotificationViewModel, CreateNotificationDto>();
            CreateMap<UpdateNotificationViewModel, UpdateNotificationDto>();
        }
    }
}