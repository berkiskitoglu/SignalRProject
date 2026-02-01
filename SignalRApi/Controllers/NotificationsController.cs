using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDtos;
using SignalR.DtoLayer.NotificationDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationsController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> NotificationsList() => Ok(_mapper.Map<List<ResultNotificationDto>>(await _notificationService.TGetListAllAsync()));

        [HttpGet("GetUnreadNotificationCountAsync")]
        public async Task<IActionResult> GetUnreadNotificationCountAsync()
        {
            var count = await _notificationService.TGetUnreadNotificationCountAsync();
            return Ok(count);
        }

        [HttpGet("GetAllUnreadNotificationsAsync")]
        public async Task<IActionResult> GetAllUnreadNotificationsAsync()
        {
            var unreadNotifications = await _notificationService.TGetlAllUnreadNotificationAsync();
            return Ok(unreadNotifications);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
        {
            createNotificationDto.Date = DateTime.Now;
            var notification = _mapper.Map<Notification>(createNotificationDto);
            await _notificationService.TAddAsync(notification);
            return Ok("Bildirim Başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var itemToDelete = await _notificationService.TGetByIDAsync(id);
            if (itemToDelete == null)
                return NotFound("Hakkımda bilgisi bulunamadı");
            await _notificationService.TDeleteAsync(itemToDelete);
            return Ok("Hakkımda Bilgisi Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotification(int id)
        {
            var notification = await _notificationService.TGetByIDAsync(id);
            if (notification == null)
                return NotFound();
            var dto = _mapper.Map<ResultNotificationDto>(notification);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification(int id, UpdateNotificationDto updateNotificationDto)
        {
            var notification = await _notificationService.TGetByIDAsync(id);
            if (notification == null)
                return NotFound("Hakkımda bilgisi bulunamadı");
            updateNotificationDto.Date = DateTime.Now;
            updateNotificationDto.Status = true;
            _mapper.Map(updateNotificationDto, notification);
            await _notificationService.TUpdateAsync(notification);
            return Ok("Bildirim  Güncellendi");
        }

        [HttpGet("NotificationChangeToTrue/{id}")]
        public async Task<IActionResult> NotificationChangeToTrue(int id)
        {
            await _notificationService.TNotificationChangeToTrue(id);
            return Ok("Bildirim durumu okundu olarak değiştirildi");
        }
        [HttpGet("NotificationChangeToFalse/{id}")]
        public async Task<IActionResult> NotificationChangeToFalse(int id)
        {
            await _notificationService.TNotificationChangeToFalse(id);
            return Ok("Bildirim durumu okunmadı olarak değiştirildi");
        }
    }
}
