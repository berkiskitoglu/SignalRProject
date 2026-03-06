using SignalRWebUI.ViewModels;

namespace SignalRWebUI.Services.Abstract
{
    public interface ITastyApiService
    {
        Task<List<TastyApiViewModel>> GetRecipesAsync();
    }
}
