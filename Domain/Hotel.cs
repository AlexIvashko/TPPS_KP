using System.Collections.Generic;

namespace travel_agency.Domain
{
    public class Hotel:EntityBase
    {
        private IList<Room> roomList = new List<Room>();
        public virtual string Name { get; set; }
        public virtual int Service { get; set; }
        public virtual Country Country { get; set; }

        public virtual IList<Room> RoomList
        {
            get { return roomList; }
            set { roomList = value; }
        }  

    }
}