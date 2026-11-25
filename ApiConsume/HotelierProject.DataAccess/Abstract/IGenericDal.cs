using HotelierProject.Entity.Common;

namespace HotelierProject.DataAccess.Abstract;

public interface IGenericDal<TEntity> where TEntity : BaseEntity
{
    Task InsertAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
}