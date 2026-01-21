namespace SignalRWebUI.Services.Abstract
{
  
        public interface IGenericApiService<ResultTDto, CreateTDto, UpdateTDto , GetTDto>
        {
            Task<List<ResultTDto>> GetAllAsync();
            Task<GetTDto?> GetByIdAsync(int id);
            Task CreateAsync(CreateTDto createDto);
            Task UpdateAsync(int id, UpdateTDto updateDto);
            Task DeleteAsync(int id);
        }


    
}
