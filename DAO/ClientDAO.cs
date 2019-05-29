using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;
using travel_agency.Domain;

namespace travel_agency.DAO
{
    public class ClientDAO:GenericDAO<Client>,IClientDAO
    {
        public ClientDAO(ISession session) : base(session) { }

        public Client getClientByName(string name)
        {
            Client client = new Client();
            ICriteria criteria = session.CreateCriteria(typeof(Client))
                .Add(Restrictions.Eq("Name", name));
            IList<Client> list = criteria.List<Client>();
            if (list.Count > 0)
                client = list[0];
            return client;
        }

        public List<string> getClientNames()
        {
            List<string> result = new List<string>();
            IList<Client> clientList = session.CreateCriteria(typeof(Client)).List<Client>();
            foreach (Client c in clientList)
            {
                result.Add(c.Name);
            }
            return result;
        }
    }
}