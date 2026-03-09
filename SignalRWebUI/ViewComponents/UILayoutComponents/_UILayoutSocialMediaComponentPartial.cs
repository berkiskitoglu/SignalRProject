using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Services.Abstract;
using SignalRWebUI.ViewModels;
using SignalRWebUI.ViewModels.SocialMediaViewModels;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutSocialMediaComponentPartial : ViewComponent
    {
        private readonly ISocialMediaApiService _socialMediaApiService;
        private readonly IMapper _mapper;

        public _UILayoutSocialMediaComponentPartial(ISocialMediaApiService socialMediaApiService, IMapper mapper)
        {
            _socialMediaApiService = socialMediaApiService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socialMediaDto = await _socialMediaApiService.GetAllAsync();
            var viewModels = _mapper.Map<List<ResultSocialMediaViewModel>>(socialMediaDto);
            return View(viewModels);
        }
    }
}
