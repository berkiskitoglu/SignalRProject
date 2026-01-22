namespace SignalR.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T: class
    {
        Task TAddAsync(T entity);
        Task TDeleteAsync(T entity);
        Task TUpdateAsync(T entity);
        Task<T?> TGetByIDAsync(int id);
        Task<List<T>> TGetListAllAsync();
    }
}
