using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<CreateMessageDto> _createValidator;
        private readonly IValidator<UpdateMessageDto> _updateValidator;

        public MessagesController(
            IMessageService messageService,
            IMapper mapper,
            IValidator<CreateMessageDto> createValidator,
            IValidator<UpdateMessageDto> updateValidator)
        {
            _messageService = messageService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> MessageList()
            => Ok(_mapper.Map<List<ResultMessageDto>>(await _messageService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            var validationResult = await _createValidator.ValidateAsync(createMessageDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            createMessageDto.MessageSendDate = DateTime.Now;
            createMessageDto.Status = false;
            await _messageService.TAddAsync(_mapper.Map<Message>(createMessageDto));
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
            var message = await _messageService.TGetByIDAsync(id);
            if (message == null)
                return NotFound("Mesaj bilgisi bulunamadı");

            return Ok(_mapper.Map<ResultMessageDto>(message));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage(int id, UpdateMessageDto updateMessageDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateMessageDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            var message = await _messageService.TGetByIDAsync(id);
            if (message == null)
                return NotFound("Mesaj bilgisi bulunamadı");

            _mapper.Map(updateMessageDto, message);
            await _messageService.TUpdateAsync(message);
            return Ok("Mesaj Bilgisi Güncellendi");
        }
    }
}