using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<int> TActiveCategoryCount() => await _categoryDal.ActiveCategoryCount();

        public async Task TAddAsync(Category entity) => await _categoryDal.AddAsync(entity);

        public async Task<int> TCategoryCountAsync() => await _categoryDal.CategoryCountAsync();

        public async Task TDeleteAsync(Category entity) => await _categoryDal.DeleteAsync(entity);

        public async Task<Category?> TGetByIDAsync(int id) => await _categoryDal.GetByIDAsync(id);

        public async Task<List<Category>> TGetListAllAsync() => await _categoryDal.GetListAllAsync();

        public async Task<int> TPassiveCategoryCount() => await _categoryDal.PassiveCategoryCount();

        public async Task TUpdateAsync(Category entity) => await _categoryDal.UpdateAsync(entity);
    }
}