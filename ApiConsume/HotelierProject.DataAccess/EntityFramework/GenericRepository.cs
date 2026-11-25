using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.Concrete;
using HotelierProject.Entity.Common;
using Microsoft.EntityFrameworkCore;

namespace HotelierProject.DataAccess.EntityFramework;

public class GenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext _context;
    
    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task InsertAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _context.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _context.Remove(entity);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }
}