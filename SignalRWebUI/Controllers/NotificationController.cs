using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.NotificationDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationApiService _notificationApiService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationApiService notificationApiService, IMapper mapper)
        {
            _notificationApiService = notificationApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> NotificationList()
        {
            var values = await _notificationApiService.GetAllAsync();
            var viewModels = _mapper.Map<List<NotificationViewModel>>(values);
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
        {
            if (!ModelState.IsValid)
                return View(createNotificationDto);

            await _notificationApiService.CreateAsync(createNotificationDto);
            return RedirectToAction("NotificationList");
        }

        public async Task<IActionResult> DeleteNotification(int id)
        {
            await _notificationApiService.DeleteAsync(id);
            return RedirectToAction("NotificationList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var value = await _notificationApiService.GetByIdAsync(id);
            if (value is null) return NotFound();
            var dto = _mapper.Map<UpdateNotificationDto>(value);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotification(int id, UpdateNotificationDto updateNotificationDto)
        {
            if (!ModelState.IsValid)
                return View(updateNotificationDto);

            await _notificationApiService.UpdateAsync(id, updateNotificationDto);
            return RedirectToAction("NotificationList");
        }

        public async Task<IActionResult> NotificationStatusChangeToTrue(int id)
        {
            await _notificationApiService.NotificationStatusChangeToTrue(id);
            return RedirectToAction("NotificationList");
        }

        public async Task<IActionResult> NotificationStatusChangeToFalse(int id)
        {
            await _notificationApiService.NotificationStatusChangeToFalse(id);
            return RedirectToAction("NotificationList");
        }
    }
}