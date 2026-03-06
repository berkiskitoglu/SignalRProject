using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactApiService _contactApiService;
        private readonly IMapper _mapper;

        public ContactController(IContactApiService contactApiService, IMapper mapper)
        {
            _contactApiService = contactApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> ContactList()
        {
            var values = await _contactApiService.GetAllAsync();
            var viewModels = _mapper.Map<List<ContactViewModel>>(values);
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            if (!ModelState.IsValid)
                return View(createContactDto);

            await _contactApiService.CreateAsync(createContactDto);
            return RedirectToAction("ContactList");
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactApiService.DeleteAsync(id);
            return RedirectToAction("ContactList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var value = await _contactApiService.GetByIdAsync(id);
            if (value is null) return NotFound();
            var dto = _mapper.Map<UpdateContactDto>(value);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(int id, UpdateContactDto updateContactDto)
        {
            if (!ModelState.IsValid)
                return View(updateContactDto);

            await _contactApiService.UpdateAsync(id, updateContactDto);
            return RedirectToAction("ContactList");
        }
    }
}