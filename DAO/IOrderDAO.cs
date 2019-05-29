using travel_agency.Domain;

namespace travel_agency.DAO
{
    public interface IOrderDAO:IGenericDAO<Order>
    {
        int calculateFullPrice(Order order);
        Order getOrderByClientNameAndDate(string clientName, string travelStarts);
    }
}
