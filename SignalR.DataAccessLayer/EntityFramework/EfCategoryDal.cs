using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

        public async Task<int> ActiveCategoryCount() => await _context.Categories.Where(x => x.Status == true).CountAsync();
        public async Task<int> CategoryCountAsync() => await _context.Categories.CountAsync();
        public async Task<int> PassiveCategoryCount() =>  await _context.Categories.Where(x => x.Status == false).CountAsync();
        public async Task<int> ReceiveCategoryCount() => await _context.Categories.CountAsync();
   
    }
}
