using NHibernate;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using travel_agency.DAO;
using travel_agency.Domain;

namespace travel_agency
{
    public partial class MakeOrderForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                DropDownList clientList = orderLoginView.FindControl("clientList") as DropDownList;
                var countryList = orderLoginView.FindControl("countryList") as DropDownList;
                var hotelList = orderLoginView.FindControl("hotelList") as DropDownList;
                var roomList = orderLoginView.FindControl("roomList") as DropDownList;
                var buttonAddOrder = orderLoginView.FindControl("buttonAddOrder") as Button;
                var TravelStarts = orderLoginView.FindControl("TravelStarts") as TextBox;
                var TravelEnds = orderLoginView.FindControl("TravelEnds") as TextBox;
                if (!IsPostBack)
                {
                    ISession session = (ISession)Session["hbmsession"];
                    DAOfactory factory = new NHibernateDAOFactory(session);
                    IClientDAO clientDAO = factory.getClientDAO();
                    List<string> dS = clientDAO.getClientNames();
                    dS.Add(" ");
                    clientList.DataSource = dS;
                    clientList.DataBind();
                    clientList.SelectedIndex = dS.Count - 1;
                    dS.Clear();

                    buttonAddOrder.Text = "Додати";
                }
                if ((string)Session["operation"] == "Edit")
                {
                    if (!IsPostBack)
                    {
                        string clientName = (string)Session["oldClientName"];
                        string countryName = (string)Session["oldCountryName"];
                        string hotelName = (string)Session["oldHotelName"];
                        string roomNumber = (string)Session["oldRoomNumber"];
                        string startDate = (string)Session["oldStartDate"];
                        string endDate = (string)Session["oldEndDate"];

                        //set old client name
                        clientList.SelectedValue = clientName;

                        ISession session = (ISession)Session["hbmsession"];
                        DAOfactory factory = new NHibernateDAOFactory(session);
                        IClientDAO clientDAO = factory.getClientDAO();
                        ICountryDAO countryDAO = factory.getCountryDAO();
                        IHotelDAO hotelDAO = factory.getHotelDAO();
                        Client c = clientDAO.getClientByName(clientName);

                        List<string> dS = countryDAO.getOffersForClient(c);

                        countryList.DataSource = dS;
                        countryList.DataBind();
                        countryList.SelectedValue = countryName;

                        dS = countryDAO.getHotelNames(countryName);
                        hotelList.DataSource = dS;
                        hotelList.DataBind();
                        hotelList.SelectedValue = hotelName;

                        dS = hotelDAO.getRoomNamesList(hotelName);
                        roomList.DataSource = dS;
                        roomList.DataBind();
                        roomList.SelectedValue = roomNumber;

                        TravelStarts.Text = startDate;
                        TravelEnds.Text = endDate;

                        buttonAddOrder.Text = "Редагувати";
                    }
                }
            }
        }

        protected void buttonAddOrder_click(object sender, EventArgs e)
        {
            var clientList = orderLoginView.FindControl("clientList") as DropDownList;
            var countryList = orderLoginView.FindControl("countryList") as DropDownList;
            var hotelList = orderLoginView.FindControl("hotelList") as DropDownList;
            var roomList = orderLoginView.FindControl("roomList") as DropDownList;
            var buttonAddOrder = orderLoginView.FindControl("buttonAddOrder") as Button;
            var TravelStarts = orderLoginView.FindControl("TravelStarts") as TextBox;
            var TravelEnds = orderLoginView.FindControl("TravelEnds") as TextBox;
            var labelMessage = orderLoginView.FindControl("labelMessage") as Label;
            if (countryList.SelectedValue != " ")
            {
                if (clientList.SelectedValue != " ")
                {
                    if (hotelList.SelectedValue != " ")
                    {
                        if (roomList.SelectedValue != " ")
                        {
                            if (TravelStarts.Text != "" || TravelEnds.Text != "")
                            {
                                ISession session = (ISession)Session["hbmsession"];
                                DAOfactory factory = new NHibernateDAOFactory(session);
                                IOrderDAO orderDAO = factory.getOrderDAO();
                                Order order;
                                if ((string)Session["operation"] == "Edit")
                                {
                                    string clientName = (string)Session["oldClientName"];
                                    string startDate = (string)Session["oldStartDate"];
                                    order = orderDAO.getOrderByClientNameAndDate(clientName, startDate);
                                }
                                else
                                {
                                    order = new Order();
                                }
                                order.Client = factory.getClientDAO().getClientByName(clientList.SelectedValue);
                                order.Room = factory.getRoomDAO().getRoomByHotelAndNumber(hotelList.SelectedValue, roomList.SelectedValue);
                                order.Travel_starts = TravelStarts.Text;
                                order.Travel_ends = TravelEnds.Text;

                                orderDAO.SaveOrUpdate(order);
                                Response.Redirect("OrderForm.aspx");
                            }
                            else
                            labelMessage.Text = "Спочатку заповніть поля дати";
                        }
                        else
                            labelMessage.Text = "Спочатку заповніть поле 'Кімната'";
                    }
                    else
                        labelMessage.Text = "Спочатку заповніть поле 'Готель'";
                }
                else
                    labelMessage.Text = "Спочатку заповніть поле 'Клієнт'";
            }
            else
                labelMessage.Text = "Спочатку заповніть поле 'Країна'";
        }
        protected void buttonCancel_click(object sender, EventArgs e)
        {
           
        }

        protected void clientList_TextChanged(object sender, EventArgs e)
        {
            var clientList = orderLoginView.FindControl("clientList") as DropDownList;
            var countryList = orderLoginView.FindControl("countryList") as DropDownList;
            var hotelList = orderLoginView.FindControl("hotelList") as DropDownList;
            var roomList = orderLoginView.FindControl("roomList") as DropDownList;
            var buttonAddOrder = orderLoginView.FindControl("buttonAddOrder") as Button;
            var TravelStarts = orderLoginView.FindControl("TravelStarts") as TextBox;
            var TravelEnds = orderLoginView.FindControl("TravelEnds") as TextBox;
            var labelMessage = orderLoginView.FindControl("labelMessage") as Label;

            string clientName = clientList.SelectedValue;
            
            if(clientName!= " ")
            {
                ISession session = (ISession)Session["hbmsession"];
                DAOfactory factory = new NHibernateDAOFactory(session);
                IClientDAO clientDAO = factory.getClientDAO();
                Client c = clientDAO.getClientByName(clientName);
                ICountryDAO countryDAO = factory.getCountryDAO();
                List<string> dS = countryDAO.getOffersForClient(c);
                dS.Add(" ");
                countryList.DataSource = dS;
                countryList.DataBind();
                countryList.SelectedIndex = dS.Count - 1;
            }
            clientList.SelectedValue = clientName;
            hotelList.DataSource = "";
            hotelList.DataBind();
            roomList.DataSource = "";
            roomList.DataBind();
        }

        protected void countryList_TextChanged(object sender, EventArgs e)
        {
            var countryList = orderLoginView.FindControl("countryList") as DropDownList;
            var hotelList = orderLoginView.FindControl("hotelList") as DropDownList;
            var roomList = orderLoginView.FindControl("roomList") as DropDownList;
            string countryName = countryList.SelectedValue;
          
            if (countryName != "")
            {
                ISession session = (ISession)Session["hbmsession"];
                DAOfactory factory = new NHibernateDAOFactory(session);
                ICountryDAO countryDAO = factory.getCountryDAO();
                
                List<string> dS = countryDAO.getHotelNames(countryName);
                hotelList.DataSource = dS;
                hotelList.DataBind();
                if (dS.Count>=1)
                {
                    IHotelDAO hotelDAO = factory.getHotelDAO();

                    dS = hotelDAO.getRoomNamesList(hotelList.SelectedValue);
                    roomList.DataSource = dS;
                    roomList.DataBind();
                }             
            }
           countryList.SelectedValue = countryName;
        }

        protected void hotelList_TextChanged(object sender, EventArgs e)
        {
            var hotelList = Page.FindControl("hotelList") as DropDownList;
            var roomList = Page.FindControl("roomList") as DropDownList;
            string hotelName = hotelList.SelectedValue;
           
            if (hotelName != "")
            {
                ISession session = (ISession)Session["hbmsession"];
                DAOfactory factory = new NHibernateDAOFactory(session);
                IHotelDAO hotelDAO = factory.getHotelDAO();

                List<string> dS = hotelDAO.getRoomNamesList(hotelName);
                roomList.DataSource = dS;
                roomList.DataBind();
            }
            hotelList.SelectedValue = hotelName;
            
        }
    }
}