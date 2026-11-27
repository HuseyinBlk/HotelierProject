using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HotelierProject.WebUI.Models;

public class ApiResult
{
    public bool IsSuccess { get; set; }
    public IDictionary<string, string[]>? ValidationErrors { get; set; }
    public string? ErrorMessage { get; set; }
    public static ApiResult Success() => new() { IsSuccess = true };
    public static ApiResult Fail(IDictionary<string, string[]>? errors, string? message = null) 
        => new() { IsSuccess = false, ValidationErrors = errors, ErrorMessage = message };

    public void AddToModelState(ModelStateDictionary modelState)
    {
        if (ValidationErrors == null) return;
        foreach (var (key, messages) in ValidationErrors)
        {
            foreach (var message in messages)
            {
                modelState.AddModelError(key, message);
            }
        }
    }
}