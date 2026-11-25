using HotelierProject.Business.Abstract;
using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.UnitOfWork;
using HotelierProject.Entity.Common;

namespace HotelierProject.Business.Concrete;

public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : BaseEntity
{
    private readonly IGenericDal<TEntity> _genericDal;
    private readonly IUnitOfWork _unitOfWork;

    public GenericManager(IGenericDal<TEntity> genericDal, IUnitOfWork unitOfWork)
    {
        _genericDal = genericDal;
        _unitOfWork = unitOfWork;
    }

    public async Task InsertAsync(TEntity entity)
    {
        await _genericDal.InsertAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _genericDal.Update(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _genericDal.Delete(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _genericDal.GetAllAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _genericDal.GetByIdAsync(id);
    }
}
