using FluentNHibernate.Mapping;
using travel_agency.Domain;

namespace travel_agency.Mapping
{
    public class OrderMap:ClassMap<Order>
    {
        public OrderMap()
        {
            Table("orders");
            Id(x => x.Id).GeneratedBy.Native();
            References(x => x.Client, "Client_ID");
            References(x => x.Room, "Room_ID");
            Map(x => x.Travel_starts);
            Map(x => x.Travel_ends);
        }
    }
}