using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        public EfMenuTableDal(SignalRContext context) : base(context)
        {
        }

        public async Task ChangeMenuTableStatusToFalse(int id)
        {
          var value =  await _context.MenuTables.Where(x => x.MenuTableID == id).FirstOrDefaultAsync();
          value.Status = false;
        }
        

        public async Task ChangeMenuTableStatusToTrue(int id)
        {
            var value = await _context.MenuTables.Where(x => x.MenuTableID == id).FirstOrDefaultAsync();
            value.Status = true;
        }


        public async Task<int> MenuTableCount() => await _context.MenuTables.CountAsync();

      
    }
}
