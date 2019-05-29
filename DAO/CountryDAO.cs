using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using travel_agency.Domain;

namespace travel_agency.DAO
{
    public class CountryDAO:GenericDAO<Country>,ICountryDAO
    {
        public CountryDAO(ISession session) : base(session) { }

        public Country getCountryByName(string name)
        {
            Country country = new Country();
            country.Name = name;
            ICriteria criteria = session.CreateCriteria(typeof(Country))
                .Add(Example.Create(country));
            IList<Country> list = criteria.List<Country>();
            country = list[0];
            return country;
        }

        public List<string> getCountryNames()
        {
            List<string> result = new List<string>();
            IList<Country> countryList = session.CreateCriteria(typeof(Country)).List<Country>();
            foreach(Country c in countryList)
            {
                result.Add(c.Name);
            }
            return result;
        }

        public List<string> getOffersForClient(Client client)
        {
            List<string> result = new List<string>();
            IList<Country> countryList = session.CreateCriteria(typeof(Country)).List<Country>();

            if (string.Compare(client.Country.Name, "США", StringComparison.OrdinalIgnoreCase) ==0)
            {
                s:
                foreach (Country c in countryList)
                {                   
                    if(string.Compare(c.Religion, "Мусульманство", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        countryList.Remove(c);
                        goto s;
                    }
                }
            }
            foreach (Country c in countryList)
            {
                result.Add(c.Name);
            }                
                return result;
        }

        public List<string> getHotelNames(string countryName)
        {
            List<string> result = new List<string>();
            var list = session.CreateSQLQuery(
                    "SELECT Hotel.* FROM Hotel JOIN Country" +
                        " ON Hotel.Country_ID = Country.ID" +
                        " WHERE Country.Name='" + countryName + "'")
                        .AddEntity("Hotel", typeof(Hotel))
                        .List<Hotel>();
            foreach(Hotel h in list)
            {
                result.Add(h.Name);
            }
            return result;
        }
    }
}