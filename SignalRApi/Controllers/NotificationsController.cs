using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
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
        private readonly IValidator<CreateNotificationDto> _createValidator;
        private readonly IValidator<UpdateNotificationDto> _updateValidator;

        public NotificationsController(
            INotificationService notificationService,
            IMapper mapper,
            IValidator<CreateNotificationDto> createValidator,
            IValidator<UpdateNotificationDto> updateValidator)
        {
            _notificationService = notificationService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> NotificationsList()
            => Ok(_mapper.Map<List<ResultNotificationDto>>(await _notificationService.TGetListAllAsync()));

        [HttpGet("GetUnreadNotificationCountAsync")]
        public async Task<IActionResult> GetUnreadNotificationCountAsync()
            => Ok(await _notificationService.TGetUnreadNotificationCountAsync());

        [HttpGet("GetAllUnreadNotificationsAsync")]
        public async Task<IActionResult> GetAllUnreadNotificationsAsync()
            => Ok(await _notificationService.TGetlAllUnreadNotificationAsync());

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var validationResult = await _createValidator.ValidateAsync(createNotificationDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            createNotificationDto.Date = DateTime.Now;
            await _notificationService.TAddAsync(_mapper.Map<Notification>(createNotificationDto));
            return Ok("Bildirim Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var itemToDelete = await _notificationService.TGetByIDAsync(id);
            if (itemToDelete == null)
                return NotFound("Bildirim bulunamadı");

            await _notificationService.TDeleteAsync(itemToDelete);
            return Ok("Bildirim Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotification(int id)
        {
            var notification = await _notificationService.TGetByIDAsync(id);
            if (notification == null)
                return NotFound("Bildirim bulunamadı");

            return Ok(_mapper.Map<ResultNotificationDto>(notification));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification(int id, UpdateNotificationDto updateNotificationDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateNotificationDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            var notification = await _notificationService.TGetByIDAsync(id);
            if (notification == null)
                return NotFound("Bildirim bulunamadı");

            updateNotificationDto.Date = DateTime.Now;
            updateNotificationDto.Status = true;
            _mapper.Map(updateNotificationDto, notification);
            await _notificationService.TUpdateAsync(notification);
            return Ok("Bildirim Güncellendi");
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