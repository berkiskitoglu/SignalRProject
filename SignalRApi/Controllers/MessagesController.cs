using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessagesController(IMessageService MessageService, IMapper mapper)
        {
            _messageService = MessageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> MessageList()
            => Ok(_mapper.Map<List<ResultMessageDto>>(await _messageService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.MessageSendDate = DateTime.Now;
            createMessageDto.Status = false;
            var Message = _mapper.Map<Message>(createMessageDto);
            await _messageService.TAddAsync(Message);
            return Ok("Mesaj Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var itemToDelete = await _messageService.TGetByIDAsync(id);
            if (itemToDelete == null)
                return NotFound("Mesaj bilgisi bulunamadı");
            await _messageService.TDeleteAsync(itemToDelete);
            return Ok("Mesaj Bilgisi Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessage(int id)
        {
            var Message = await _messageService.TGetByIDAsync(id);
            if (Message == null)
                return NotFound();
            var dto = _mapper.Map<ResultMessageDto>(Message);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage(int id, UpdateMessageDto updateMessageDto)
        {
            var Message = await _messageService.TGetByIDAsync(id);
            if (Message == null)
                return NotFound("Mesaj bilgisi bulunamadı");
            _mapper.Map(updateMessageDto, Message);
            await _messageService.TUpdateAsync(Message);
            return Ok("Mesaj Bilgisi Güncellendi");
        }
    }
}
