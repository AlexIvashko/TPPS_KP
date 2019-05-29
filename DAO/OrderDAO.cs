using NHibernate;
using System;
using System.Collections.Generic;
using travel_agency.Domain;

namespace travel_agency.DAO
{
    public class OrderDAO:GenericDAO<Order>,IOrderDAO
    {
        public OrderDAO(ISession session) : base(session) { }
        public int calculateFullPrice(Order order)
        {
            DateTime start = DateTime.Parse(order.Travel_starts);
            DateTime finish = DateTime.Parse(order.Travel_ends);
            int difference = finish.Subtract(start).Days;
                return difference; 
        } 
        public Order getOrderByClientNameAndDate(string clientName, string travelStarts)
        {
            IQuery query = session.CreateQuery(
                "Select ord from Order as ord inner join ord.Client as cl where cl.Name=:Name and ord.Travel_starts=:Start");
            query.SetAnsiString("Name", clientName);
            query.SetAnsiString("Start", travelStarts);
            IList<Order> result = query.List<Order>();
                return result[0];
        }

    }
}