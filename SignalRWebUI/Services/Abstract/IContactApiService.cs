using SignalRWebUI.Dtos.ContactDtos;

namespace SignalRWebUI.Services.Abstract
{
    public interface IContactApiService : IGenericApiService<ResultContactDto,CreateContactDto,UpdateContactDto,GetContactDto>
    {
    }
}
