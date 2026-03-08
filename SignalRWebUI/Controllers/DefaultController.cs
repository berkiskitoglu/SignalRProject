using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.MessageDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels.MessageViewModels;

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

        public IActionResult Index() => View();

        [HttpGet]
        public PartialViewResult SendMessage() => PartialView();

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageViewModel createMessageViewModel)
        {
            if (!ModelState.IsValid)
                return PartialView(createMessageViewModel);

            CreateMessageDto createMessageDto = _mapper.Map<CreateMessageDto>(createMessageViewModel);
            createMessageDto.MessageSendDate = DateTime.Now;
            createMessageDto.Status = true;
            await _messageApiService.CreateAsync(createMessageDto);
            return Json(new { success = true, message = "Mesaj başarıyla gönderildi" });
        }
    }
}