using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;
using travel_agency.Domain;

namespace travel_agency.DAO
{
    public class HotelDAO:GenericDAO<Hotel>,IHotelDAO
    {
        public HotelDAO(ISession session) : base(session) { }
        public IList<Room> getAllRooms(string hotelName)
        {
            var list = session.CreateSQLQuery(
               "SELECT Room.* FROM Room JOIN Hotel" +
               " ON Room.Hotel_ID = Hotel.ID" +
               " WHERE Hotel.Name='" + hotelName + "'")
               .AddEntity("Room", typeof(Room))
               .List<Room>();
            return list;
        }

        public Hotel getHotelByName(string name)
        {
            Hotel hotel = new Hotel();
            ICriteria criteria = session.CreateCriteria(typeof(Hotel))
                .Add(Restrictions.Eq("Name",name));
            IList<Hotel> list = criteria.List<Hotel>();
            if(list.Count>0)
                hotel = list[0];
            return hotel;
        }

        public List<string> getHotelNames()
        {
            List<string> result = new List<string>();
            IList<Hotel> hotelList = session.CreateCriteria(typeof(Hotel)).List<Hotel>();
            foreach (Hotel h in hotelList)
            {
                result.Add(h.Name);
            }
            return result;
        }

        public List<string> getRoomNamesList(string hotelName)
        {
            List<string> result = new List<string>();
            foreach(Room r in getAllRooms(hotelName))
            {
                result.Add(r.Number.ToString());
            }
            return result;
        }
    }
}