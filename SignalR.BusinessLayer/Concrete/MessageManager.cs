using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {

        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public async Task TAddAsync(Message entity) => await _messageDal.AddAsync(entity);

        public async Task TUpdateAsync(Message entity) => await _messageDal.UpdateAsync(entity);

        public async Task TDeleteAsync(Message entity) => await _messageDal.DeleteAsync(entity);

        public async Task<Message?> TGetByIDAsync(int id) => await _messageDal.GetByIDAsync(id);

        public async Task<List<Message>> TGetListAllAsync() => await _messageDal.GetListAllAsync();
    }
}
