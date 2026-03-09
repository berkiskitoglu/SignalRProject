using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateContactDto> _createValidator;
        private readonly IValidator<UpdateContactDto> _updateValidator;

        public ContactsController(
            IContactService contactService,
            IMapper mapper,
            IValidator<CreateContactDto> createValidator,
            IValidator<UpdateContactDto> updateValidator)
        {
            _contactService = contactService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
            => Ok(_mapper.Map<List<ResultContactDto>>(await _contactService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var validationResult = await _createValidator.ValidateAsync(createContactDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            await _contactService.TAddAsync(_mapper.Map<Contact>(createContactDto));
            return Ok("İletişim Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var itemToDelete = await _contactService.TGetByIDAsync(id);
            if (itemToDelete == null)
                return NotFound("İletişim Bilgisi bulunamadı");

            await _contactService.TDeleteAsync(itemToDelete);
            return Ok("İletişim Bilgisi Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var contact = await _contactService.TGetByIDAsync(id);
            if (contact == null)
                return NotFound("İletişim Bilgisi bulunamadı");

            return Ok(_mapper.Map<ResultContactDto>(contact));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, UpdateContactDto updateContactDto)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateContactDto);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { Field = e.PropertyName, Message = e.ErrorMessage });
                return BadRequest(errors);
            }

            var contact = await _contactService.TGetByIDAsync(id);
            if (contact == null)
                return NotFound("İletişim Bilgisi bulunamadı");

            _mapper.Map(updateContactDto, contact);
            await _contactService.TUpdateAsync(contact);
            return Ok("İletişim Bilgisi Güncellendi");
        }
    }
}