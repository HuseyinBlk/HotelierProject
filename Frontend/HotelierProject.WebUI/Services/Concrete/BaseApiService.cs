using System.Net;
using HotelierProject.WebUI.Models;
using HotelierProject.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HotelierProject.WebUI.Services.Concrete;

public class BaseApiService<TResult,TCreate,TUpdate>(HttpClient httpClient, string endpoint)  : IBaseApiService<TResult,TCreate,TUpdate>
{
    protected readonly HttpClient HttpClient = httpClient;

    public async Task<List<TResult>> GetAllAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<TResult>>(endpoint) ?? new List<TResult>();
    }

    public async Task<TResult?> GetByIdAsync(int id)
    {
        return await HttpClient.GetFromJsonAsync<TResult>($"{endpoint}/{id}");
    }

    public async Task<TUpdate?> GetByIdForUpdateAsync(int id)
    {
        return await HttpClient.GetFromJsonAsync<TUpdate>($"{endpoint}/{id}");
    }

    public async Task<ApiResult> CreateAsync(TCreate dto)
    {
        var response = await HttpClient.PostAsJsonAsync(endpoint, dto);
        if (response.IsSuccessStatusCode)
        {
            return ApiResult.Success();
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var problemDetails = await  response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
            return ApiResult.Fail(problemDetails?.Errors);
        }
        
        return ApiResult.Fail(null, "Ekleme sırasında bir hata oluştu.");
    }

    public async Task<ApiResult> UpdateAsync(TUpdate dto)
    {
        var response = await HttpClient.PutAsJsonAsync(endpoint, dto);
        if (response.IsSuccessStatusCode)
        {
            return ApiResult.Success();
        }

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var problemDetails = await  response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
            return ApiResult.Fail(problemDetails?.Errors);
        }
        
        return ApiResult.Fail(null, "Güncelleme sırasında bir hata oluştu.");
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await HttpClient.DeleteAsync($"{endpoint}/{id}");
        return response.IsSuccessStatusCode;
    }
}