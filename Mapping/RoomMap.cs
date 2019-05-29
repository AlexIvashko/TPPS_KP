using FluentNHibernate.Mapping;
using travel_agency.Domain;

namespace travel_agency.Mapping
{
    public class RoomMap:ClassMap<Room>
    {
        public RoomMap()
        {
            Table("room");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Number);
            Map(x => x.Type);
            Map(x => x.Price);
            Map(x => x.Size);
            References(x => x.Hotel, "Hotel_ID");
        }
    }
}