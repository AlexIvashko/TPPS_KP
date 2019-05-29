using NHibernate;
using travel_agency.Domain;

namespace travel_agency.DAO
{
    public class RoomDAO:GenericDAO<Room>,IRoomDAO
    {
        public RoomDAO(ISession session) : base(session) { }

        public Room getRoomByHotelAndNumber(string hotelName, string roomNumber)
        {
            var list = session.CreateSQLQuery(
               "SELECT Room.* FROM Room JOIN Hotel" +
               " ON Room.Hotel_ID = Hotel.Id" +
               " WHERE Hotel.Name='" + hotelName + "'" +
               " and Room.Number='" + roomNumber + "'")
               .AddEntity("Room", typeof(Room)).List<Room>();
            Room room = list[0];
            return room;

        }
    }
}