namespace SignalRWebUI.Services.Abstract
{

    // Sadece GetAll
    public interface IReadOnlyApiService<ResultTDto>
    {
        Task<List<ResultTDto>> GetAllAsync();
    }

    // GetById ama List döner (örn: Basket'in Products'ları)
    public interface IGetByIdListApiService<ResultTDto>
    {
        Task<List<ResultTDto>> GetByIdAsync(int id);
    }

    // GetAll + GetById
    public interface IReadApiService<ResultTDto, GetTDto>
    {
        Task<List<ResultTDto>> GetAllAsync();
        Task<GetTDto?> GetByIdAsync(int id);
    }
    public interface IGenericApiService<ResultTDto, CreateTDto, UpdateTDto, GetTDto>
    {
        Task<List<ResultTDto>> GetAllAsync();
        Task<GetTDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateTDto createDto);
        Task UpdateAsync(int id, UpdateTDto updateDto);
        Task DeleteAsync(int id);
    }



}
