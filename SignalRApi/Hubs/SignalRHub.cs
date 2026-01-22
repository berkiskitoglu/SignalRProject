using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;

        public SignalRHub(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

      
    }
}
