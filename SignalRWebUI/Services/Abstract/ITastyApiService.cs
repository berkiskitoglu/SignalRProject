using SignalRWebUI.ViewModels.RapidApiViewModels;

namespace SignalRWebUI.Services.Abstract
{
    public interface ITastyApiService
    {
        Task<List<TastyApiViewModel>> GetRecipesAsync();
    }
}
