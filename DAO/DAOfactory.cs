namespace travel_agency.DAO
{
    public abstract class DAOfactory
    {
        public abstract ICountryDAO getCountryDAO();
        public abstract IHotelDAO getHotelDAO();
        public abstract IRoomDAO getRoomDAO();
        public abstract IOrderDAO getOrderDAO();
        public abstract IClientDAO getClientDAO();
    }
}