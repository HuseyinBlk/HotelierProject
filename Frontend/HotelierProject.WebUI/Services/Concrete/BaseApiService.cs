using System.Net;
using System.Net.Http.Json;
using HotelierProject.WebUI.Models;
using HotelierProject.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.Services.Concrete;

public class BaseApiService<TResult, TCreate, TUpdate>(HttpClient httpClient, string endpoint) 
    : IBaseApiService<TResult, TCreate, TUpdate>
{
    public async Task<List<TResult>> GetAllAsync()
    {
        return await httpClient.GetFromJsonAsync<List<TResult>>(endpoint) ?? new List<TResult>();
    }

    public async Task<TResult?> GetByIdAsync(int id)
    {
        var response = await httpClient.GetAsync($"{endpoint}/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return default;
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TResult>();
    }

    public async Task<TUpdate?> GetByIdForUpdateAsync(int id)
    {
        var response = await httpClient.GetAsync($"{endpoint}/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return default;
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TUpdate>();
    }

    public async Task<ApiResult> CreateAsync(TCreate dto)
    {
        var response = await httpClient.PostAsJsonAsync(endpoint, dto);
        if (response.IsSuccessStatusCode)
        {
            return ApiResult.Success();
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
            return ApiResult.Fail(problemDetails?.Errors);
        }
        
        return ApiResult.Fail(null, "Ekleme sırasında bir hata oluştu.");
    }

    public async Task<ApiResult> UpdateAsync(TUpdate dto)
    {
        var response = await httpClient.PutAsJsonAsync(endpoint, dto);
        if (response.IsSuccessStatusCode)
        {
            return ApiResult.Success();
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
            return ApiResult.Fail(problemDetails?.Errors);
        }
        
        return ApiResult.Fail(null, "Güncelleme sırasında bir hata oluştu.");
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await httpClient.DeleteAsync($"{endpoint}/{id}");
        return response.IsSuccessStatusCode;
    }
}
