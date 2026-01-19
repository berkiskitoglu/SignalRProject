using SignalRWebUI.Dtos.CategoryDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface ICategoryApiService
    {
        Task<List<ResultCategoryDto>> GetAllAsync();
        Task<GetCategoryDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateCategoryDto createCategoryDto);
        Task UpdateAsync(int id , UpdateCategoryDto updateCategoryDto);
        Task DeleteAsync(int id);
    }
}
