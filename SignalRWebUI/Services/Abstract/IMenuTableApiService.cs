using SignalRWebUI.Dtos.MenuTableDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface IMenuTableApiService : IGenericApiService<ResultMenuTableDto,CreateMenuTableDto,UpdateMenuTableDto,GetMenuTableDto>
    {
    }
}
