using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.Concrete;
using HotelierProject.Entity.Common;
using Microsoft.EntityFrameworkCore;

namespace HotelierProject.DataAccess.EntityFramework;

public class GenericRepository<TEntity>(AppDbContext context) : IGenericDal<TEntity> where TEntity : BaseEntity
{
    public async Task InsertAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }
}
