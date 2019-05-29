    using travel_agency.Domain;

    namespace travel_agency.DAO
    {
        public interface IRoomDAO:IGenericDAO<Room>
        {
            Room getRoomByHotelAndNumber(string hotelName, string roomNumber);
        }
    }
