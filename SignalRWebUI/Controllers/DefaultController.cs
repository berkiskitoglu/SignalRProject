using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.MessageDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IMessageApiService _messageApiService;
        private readonly IMapper _mapper;

        public DefaultController(IMessageApiService messageApiService, IMapper mapper)
        {
            _messageApiService = messageApiService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageViewModel messageViewModel)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(messageViewModel);
            }

            messageViewModel.MessageSendDate = DateTime.Now;
            messageViewModel.Status = true;
            var createMessageDto = _mapper.Map<CreateMessageDto>(messageViewModel);
            await _messageApiService.CreateAsync(createMessageDto);
            return Json(new { success = true, message = "Mesaj başarıyla gönderildi" });
        }
    }
}