using SignalRWebUI.Dtos.AboutDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface IAboutApiService : IGenericApiService<ResultAboutDto, CreateAboutDto, UpdateAboutDto, GetAboutDto>
    {
       
    }
}
