using HotelierProject.WebUI.Models.Subscribe;
using HotelierProject.WebUI.Services.Abstract;

namespace HotelierProject.WebUI.Services.Concrete;

public class SubscribeApiService(HttpClient httpClient) 
    : BaseApiService<SubscribeViewModel, CreateSubscribeViewModel, UpdateSubscribeViewModel>(httpClient, "Subscribe"), ISubscribeApiService
{
}