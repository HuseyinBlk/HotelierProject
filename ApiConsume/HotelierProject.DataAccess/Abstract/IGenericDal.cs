using HotelierProject.Entity.Common;

namespace HotelierProject.DataAccess.Abstract;

public interface IGenericDal<TEntity> where TEntity : BaseEntity
{
    Task InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
}