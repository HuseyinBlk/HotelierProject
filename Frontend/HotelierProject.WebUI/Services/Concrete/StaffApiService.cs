using HotelierProject.WebUI.Models.Staff;
using HotelierProject.WebUI.Services.Abstract;

namespace HotelierProject.WebUI.Services.Concrete;

public class StaffApiService(HttpClient httpClient) 
    : BaseApiService<StaffViewModel, CreateStaffViewModel, UpdateStaffViewModel>(httpClient, "Staff"), IStaffApiService
{
}