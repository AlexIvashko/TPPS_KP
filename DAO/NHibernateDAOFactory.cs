using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace travel_agency.DAO
{
    public class NHibernateDAOFactory:DAOfactory
    {
        /** NHibernate sessionFactory */
        protected ISession session = null;

        public NHibernateDAOFactory(ISession session)
        {
            this.session = session;
        }
        public override ICountryDAO getCountryDAO()
        {
            return new CountryDAO(session);
        }
        public override IHotelDAO getHotelDAO()
        {
            return new HotelDAO(session);
        }
        public override IRoomDAO getRoomDAO()
        {
            return new RoomDAO(session);
        }
        public override IClientDAO getClientDAO()
        {
            return new ClientDAO(session);
        }
        public override IOrderDAO getOrderDAO()
        {
            return new OrderDAO(session);
        }
    }
}