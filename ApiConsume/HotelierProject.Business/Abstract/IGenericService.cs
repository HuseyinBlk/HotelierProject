using HotelierProject.Entity.Common;

namespace HotelierProject.Business.Abstract;

public interface IGenericService<TEntity> where TEntity : BaseEntity
{
    Task InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
}