using HotelierProject.Entity.Common;

namespace HotelierProject.Business.Abstract;

public interface IGenericService<TResultDto, TCreateDto, TUpdateDto>
{
    Task CreateAsync(TCreateDto createDto);
    Task UpdateAsync(TUpdateDto updateDto);
    Task DeleteAsync(int id);
    Task<List<TResultDto>> GetAllAsync();
    Task<TResultDto?> GetByIdAsync(int id);
}