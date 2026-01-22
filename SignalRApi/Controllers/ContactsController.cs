using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
            => Ok(_mapper.Map<List<ResultContactDto>>(await _contactService.TGetListAllAsync()));

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var contact = _mapper.Map<Contact>(createContactDto);
            await _contactService.TAddAsync(contact);
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
                return NotFound();
            var dto = _mapper.Map<ResultContactDto>(contact);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, UpdateContactDto updateContactDto)
        {
            var contact = await _contactService.TGetByIDAsync(id);
            if (contact == null)
                return NotFound("İletişim Bilgisi bulunamadı");
            _mapper.Map(updateContactDto, contact);
            await _contactService.TUpdateAsync(contact);
            return Ok("İletişim Bilgisi Güncellendi");
        }
    }
}