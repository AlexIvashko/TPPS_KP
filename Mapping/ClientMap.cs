using FluentNHibernate.Mapping;
using travel_agency.Domain;

namespace travel_agency.Mapping
{
    public class ClientMap:ClassMap<Client>
    {
        public ClientMap()
        {
            Table("client");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.Age);
            References(x => x.Country, "Native_country");
        }
    }
}