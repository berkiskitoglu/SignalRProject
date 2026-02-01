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



        public NotificationController(INotificationApiService NotificationApiService, IMapper mapper)
        {
            _notificationApiService = NotificationApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> NotificationList()
        {
            var values = await _notificationApiService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(NotificationViewModel notificationViewModel)
        {

            var createNotificationDto = _mapper.Map<CreateNotificationDto>(notificationViewModel);
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
            var viewModel = _mapper.Map<NotificationViewModel>(value);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotification(int id, NotificationViewModel notificationViewModel)
        {

            var dto = _mapper.Map<UpdateNotificationDto>(notificationViewModel);
            await _notificationApiService.UpdateAsync(id, dto);
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
