using HotelierProject.WebUI.Models;

namespace HotelierProject.WebUI.Services.Abstract;

public interface IBaseApiService<TResultDto, TCreateDto, TUpdateDto>
{
    Task<List<TResultDto>> GetAllAsync();
    Task<TResultDto?> GetByIdAsync(int id);
    Task<TUpdateDto?> GetByIdForUpdateAsync(int id);
    Task<ApiResult> CreateAsync(TCreateDto dto);
    Task<ApiResult> UpdateAsync(TUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}