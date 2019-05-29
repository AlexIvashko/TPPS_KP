using System.Collections.Generic;
using travel_agency.Domain;

namespace travel_agency.DAO
{
    public interface ICountryDAO:IGenericDAO<Domain.Country>
    {
        Country getCountryByName(string countryName);
        List<string> getCountryNames();
        List<string> getOffersForClient(Client client);
        List<string> getHotelNames(string countryName);
    }
}
