using System.Collections.Generic;
using travel_agency.Domain;

namespace travel_agency.DAO
{
    public interface IHotelDAO:IGenericDAO<Hotel>
    {
        IList<Room> getAllRooms(string hotelName);
        Hotel getHotelByName(string name);
        List<string> getHotelNames();
        List<string> getRoomNamesList(string hotelName);
    }
}
