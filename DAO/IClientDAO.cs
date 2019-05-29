using System.Collections.Generic;
using travel_agency.Domain;

namespace travel_agency.DAO
{
    public interface IClientDAO:IGenericDAO<Client>
    {
        Client getClientByName(string name);
        List<string> getClientNames();
    }
}
