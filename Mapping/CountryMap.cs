using FluentNHibernate.Mapping;
using travel_agency.Domain;

namespace travel_agency.Mapping
{
    public class CountryMap : ClassMap<Country>
    {
        public CountryMap(){
        Table("country");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.Capital);
            Map(x => x.Language);
            Map(x => x.Currency);
            Map(x => x.Religion);
        }
    }
}