using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactsController(IContactService ContactService, IMapper mapper)
        {
            _contactService = ContactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var contactList = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(contactList);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var contact = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(contact);
            return Ok("İletişim Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var itemToDelete = _contactService.TGetByID(id);
            _contactService.TDelete(itemToDelete);
            return Ok("İletişim Bilgisi Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var getContactById = _contactService.TGetByID(id);
            return Ok(getContactById);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id , UpdateContactDto updateContactDto)
        {
            var contact = _contactService.TGetByID(id);
            if (contact == null)
            {
                return NotFound("İletişim Bilgisi bulunamadı");
            }
            _mapper.Map(updateContactDto, contact);
            _contactService.TUpdate(contact);
            return Ok("İletişim Bilgisi Güncellendi");
        }
    }
}
