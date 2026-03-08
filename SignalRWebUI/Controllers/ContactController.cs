using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels.ContactViewModels;

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
            List<ResultContactDto> values = await _contactApiService.GetAllAsync();
            List<ResultContactViewModel> resultContactViewModels = _mapper.Map<List<ResultContactViewModel>>(values);
            return View(resultContactViewModels);
        }

        [HttpGet]
        public IActionResult CreateContact() => View();

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactViewModel createContactViewModel)
        {
            if (!ModelState.IsValid)
                return View(createContactViewModel);

            CreateContactDto createContactDto = _mapper.Map<CreateContactDto>(createContactViewModel);
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
            GetContactDto getContactDto = await _contactApiService.GetByIdAsync(id);
            if (getContactDto is null) return NotFound();
            UpdateContactViewModel updateContactViewModel = _mapper.Map<UpdateContactViewModel>(getContactDto);
            return View(updateContactViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(int id, UpdateContactViewModel updateContactViewModel)
        {
            if (!ModelState.IsValid)
                return View(updateContactViewModel);

            UpdateContactDto updateContactDto = _mapper.Map<UpdateContactDto>(updateContactViewModel);
            await _contactApiService.UpdateAsync(id, updateContactDto);
            return RedirectToAction("ContactList");
        }
    }
}