using HotelierProject.WebUI.Models.Service;
using HotelierProject.WebUI.Services.Abstract;

namespace HotelierProject.WebUI.Services.Concrete;

public class ServiceApiService(HttpClient httpClient) 
    : BaseApiService<ServiceViewModel, CreateServiceViewModel, UpdateServiceViewModel>(httpClient, "Service"), IServiceApiService
{
}