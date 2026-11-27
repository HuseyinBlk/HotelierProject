using HotelierProject.WebUI.Models.Room;
using HotelierProject.WebUI.Services.Abstract;

namespace HotelierProject.WebUI.Services.Concrete;

public class RoomApiService(HttpClient httpClient) 
    : BaseApiService<RoomViewModel, CreateRoomViewModel, UpdateRoomViewModel>(httpClient, "Room"), IRoomApiService
{
}