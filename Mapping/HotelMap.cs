using FluentNHibernate.Mapping;
using travel_agency.Domain;

namespace travel_agency.Mapping
{
    public class HotelMap:ClassMap<Hotel>
    {
        public HotelMap(){
            Table("hotel");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.Service);
            References(x => x.Country, "Country_ID");
            //Связь один ко многим
            HasMany(x => x.RoomList)
                .KeyColumns.Add("Hotel_ID")
                .Inverse()
                .Cascade.All();
        }
    }
}