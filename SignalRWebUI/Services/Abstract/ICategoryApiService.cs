using SignalRWebUI.Dtos.CategoryDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface ICategoryApiService : IGenericApiService<ResultCategoryDto,CreateCategoryDto,UpdateCategoryDto,GetCategoryDto>
    {
       
    }
}
