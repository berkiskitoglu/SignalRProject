using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.ContactDtos;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactApiService _ContactApiService;
        private readonly IMapper _mapper;



        public ContactController(IContactApiService ContactApiService, IMapper mapper)
        {
            _ContactApiService = ContactApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> ContactList()
        {
            var values = await _ContactApiService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactViewModel ContactViewModel)
        {

            var createContactDto = _mapper.Map<CreateContactDto>(ContactViewModel);
            await _ContactApiService.CreateAsync(createContactDto);
            return RedirectToAction("ContactList");
        }

        public async Task<IActionResult> DeleteContact(int id)
        {

            await _ContactApiService.DeleteAsync(id);
            return RedirectToAction("ContactList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var value = await _ContactApiService.GetByIdAsync(id);
            var viewModel = _mapper.Map<ContactViewModel>(value);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(int id, ContactViewModel ContactViewModel)
        {

            var dto = _mapper.Map<UpdateContactDto>(ContactViewModel);
            await _ContactApiService.UpdateAsync(id, dto);
            return RedirectToAction("ContactList");
        }
    }
}
