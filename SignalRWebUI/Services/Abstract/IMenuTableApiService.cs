using SignalRWebUI.Dtos.MenuTableDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface IMenuTableApiService : IGenericApiService<ResultMenuTableDto,CreateMenuTableDto,UpdateMenuTableDto,GetMenuTableDto>
    {
        Task TChangeMenuTableStatusToTrue(int id);
        Task TChangeMenuTableStatusToFalse(int id);
    }
}
