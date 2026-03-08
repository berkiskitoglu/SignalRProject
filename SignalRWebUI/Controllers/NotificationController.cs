using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.NotificationDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels.NotificationViewModels;

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
            List<ResultNotificationDto> values = await _notificationApiService.GetAllAsync();
            List<ResultNotificationViewModel> resultNotificationViewModels = _mapper.Map<List<ResultNotificationViewModel>>(values);
            return View(resultNotificationViewModels);
        }

        [HttpGet]
        public IActionResult CreateNotification() => View();

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationViewModel createNotificationViewModel)
        {
            if (!ModelState.IsValid)
                return View(createNotificationViewModel);

            CreateNotificationDto createNotificationDto = _mapper.Map<CreateNotificationDto>(createNotificationViewModel);
            createNotificationDto.Date = DateTime.Now;
            createNotificationDto.Status = false;
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
            GetNotificationDto getNotificationDto = await _notificationApiService.GetByIdAsync(id);
            if (getNotificationDto is null) return NotFound();
            UpdateNotificationViewModel updateNotificationViewModel = _mapper.Map<UpdateNotificationViewModel>(getNotificationDto);
            return View(updateNotificationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotification(int id, UpdateNotificationViewModel updateNotificationViewModel)
        {
            if (!ModelState.IsValid)
                return View(updateNotificationViewModel);

            UpdateNotificationDto updateNotificationDto = _mapper.Map<UpdateNotificationDto>(updateNotificationViewModel);
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