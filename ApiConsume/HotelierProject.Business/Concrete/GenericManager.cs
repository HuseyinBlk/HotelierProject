using HotelierProject.Business.Abstract;
using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.UnitOfWork;
using HotelierProject.DTO.Abstract;
using HotelierProject.Entity.Common;
using Mapster;

namespace HotelierProject.Business.Concrete;

public class GenericManager<TEntity,TResultDto, TCreateDto, TUpdateDto> : IGenericService<TResultDto, TCreateDto, TUpdateDto> where TEntity : BaseEntity where TUpdateDto : IBaseDto
{
    protected readonly IGenericDal<TEntity> GenericDal;
    protected readonly IUnitOfWork UnitOfWork;

    public GenericManager(IGenericDal<TEntity> genericDal, IUnitOfWork unitOfWork)
    {
        GenericDal = genericDal;
        UnitOfWork = unitOfWork;
    }

    public async Task CreateAsync(TCreateDto createDto)
    {
        var entity = createDto.Adapt<TEntity>();
        await GenericDal.InsertAsync(entity);
        await UnitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(TUpdateDto updateDto)
    {
        var entity = await GenericDal.GetByIdAsync(updateDto.Id);
        if (entity == null) return;
        
        updateDto.Adapt(entity);
        GenericDal.Update(entity);
        await UnitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GenericDal.GetByIdAsync(id);
        if (entity == null) return;
        GenericDal.Delete(entity);
        await UnitOfWork.SaveChangesAsync();
    }

    public async Task<List<TResultDto>> GetAllAsync()
    {
        var entities = await GenericDal.GetAllAsync();
        return entities.Adapt<List<TResultDto>>();
    }

    public async Task<TResultDto?> GetByIdAsync(int id)
    {
        var entity = await GenericDal.GetByIdAsync(id);
        return entity.Adapt<TResultDto>();
    }
}
