using HotelierProject.Business.Abstract;
using HotelierProject.DataAccess.Abstract;
using HotelierProject.DataAccess.UnitOfWork;
using HotelierProject.DTO.Abstract;
using HotelierProject.Entity.Common;
using Mapster;

namespace HotelierProject.Business.Concrete;

public class GenericManager<TEntity, TResultDto, TCreateDto, TUpdateDto>(
    IGenericDal<TEntity> genericDal,
    IUnitOfWork unitOfWork) 
    : IGenericService<TResultDto, TCreateDto, TUpdateDto> 
    where TEntity : BaseEntity 
    where TUpdateDto : IBaseDto
{
    public async Task CreateAsync(TCreateDto createDto)
    {
        var entity = createDto.Adapt<TEntity>();
        await genericDal.InsertAsync(entity);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(TUpdateDto updateDto)
    {
        var entity = await genericDal.GetByIdAsync(updateDto.Id);
        if (entity == null)
        {
            throw new KeyNotFoundException("Güncellenecek kayıt bulunamadı.");
        }
        
        updateDto.Adapt(entity);
        genericDal.Update(entity);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await genericDal.GetByIdAsync(id);
        if (entity == null) return;
        
        genericDal.Delete(entity);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task<List<TResultDto>> GetAllAsync()
    {
        var entities = await genericDal.GetAllAsync();
        return entities.Adapt<List<TResultDto>>();
    }

    public async Task<TResultDto?> GetByIdAsync(int id)
    {
        var entity = await genericDal.GetByIdAsync(id);
        return entity.Adapt<TResultDto>();
    }
}
