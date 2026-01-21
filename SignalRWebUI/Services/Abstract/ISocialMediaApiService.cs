using SignalRWebUI.Dtos.SocialMediaDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface ISocialMediaApiService : IGenericApiService<ResultSocialMediaDto,CreateSocialMediaDto,UpdateSocialMediaDto,GetSocialMediaDto>
    {
    }
}
