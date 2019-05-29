using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using travel_agency.DAO;
using travel_agency.Domain;

namespace travel_agency
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            ISession session = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(session);
            IHotelDAO hotelDAO = factory.getHotelDAO();       
            List<Hotel> hotels = hotelDAO.GetAll();
            if (hotels.Count > 3)
            {
                IOrderDAO orderDAO = factory.getOrderDAO();
                List<Order> orders = orderDAO.GetAll();
                Dictionary<Hotel, int> d = new Dictionary<Hotel, int>();
                foreach (Hotel h in hotels)
                {
                    int n = 0;
                    foreach (Order o in orders)
                    {
                        if (o.Room.Hotel == h)
                        {
                            n++;
                        }
                    }
                    d.Add(h, n);
                }
                List<Hotel> dataSource = new List<Hotel>();
                for (int i = 0; i < 3; i++)
                {
                    Hotel hotel = new Hotel();
                    int max = 0;
                    foreach (Hotel h in hotels)
                    {
                        int value = 0;
                        d.TryGetValue(h, out value);
                        if (value > max)
                        {
                            max = value;
                            hotel = h;
                        }
                    }
                    dataSource.Add(hotel);
                    hotels.Remove(hotel);
                }
                GridView1.DataSource = dataSource;
                GridView1.DataBind();
            }
            else {
                GridView1.DataSource = hotels;
                GridView1.DataBind();
            }
        }

        //Изменение номера текущей страницы
        protected void GridView1_PageIndexChanging(object sender,
          GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.EditIndex = -1;
            GridView1.ShowFooter = true;
            GridView1.DataBind();
        }
    }
}