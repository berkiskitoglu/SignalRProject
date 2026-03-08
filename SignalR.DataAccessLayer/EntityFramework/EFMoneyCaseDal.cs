using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EFMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        public EFMoneyCaseDal(SignalRContext context) : base(context)
        {
        }

        public async Task<decimal> TotalMoneyCaseAmount() => await _context.MoneyCases.Select(x => x.TotalAmount).FirstAsync();

    }
}
