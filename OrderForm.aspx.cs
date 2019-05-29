using NHibernate;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using travel_agency.DAO;
using travel_agency.Domain;

namespace travel_agency
{
    public partial class OrderForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            if (User.IsInRole("Administrator") | User.IsInRole("Supervisor"))
            {
                var GridView1 = loginViewOrders.FindControl("GridView1") as GridView;
                ISession session = (ISession)Session["hbmsession"];
                DAOfactory factory = new NHibernateDAOFactory(session);
                IOrderDAO orderDAO = factory.getOrderDAO();
                List<Order> orders = orderDAO.GetAll();
                GridView1.DataSource = orders;
                GridView1.DataBind();
            }    
        }

        //Обработчик нажатия на добавить
        protected void ibInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("MakeOrderForm.aspx");
        }

        //Удаление записи
        protected void GridView1_RowDeleting(object sender,
          GridViewDeleteEventArgs e)
        {
            var GridView1 = loginViewOrders.FindControl("GridView1") as GridView;
            //Получить индекс выделенной строки
            int index = e.RowIndex;
            GridViewRow row = GridView1.Rows[index];
            //Получить имя клиента и начало тура
            string orderID = ((Label)(row.Cells[0].FindControl("myLabel0"))).Text;
            //Создание DAO заказа
            ISession hbmSession = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(hbmSession);
            IOrderDAO orderDAO = factory.getOrderDAO();
            //Получение заказа по имени
            Order order = orderDAO.GetById(Convert.ToInt64(orderID));
            //Удаление заказа
            if (order != null)
            {
                orderDAO.Delete(order);
            }
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        //Перевести строку в режим редактирования
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var GridView1 = sender as GridView;
            //Получить индекс выделенной строки
            int index = e.NewEditIndex;
            GridViewRow row = GridView1.Rows[index];
            //Получение старых значений полей в строке GridView
            string oldClientName = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;
            string oldCountryName = ((Label)(row.Cells[1].FindControl("myLabel2"))).Text;
            string oldHotelName = ((Label)(row.Cells[2].FindControl("myLabel3"))).Text;
            string oldRoomNumber = ((Label)(row.Cells[3].FindControl("myLabel4"))).Text;
            string oldStartDate = ((Label)(row.Cells[4].FindControl("myLabel5"))).Text;
            string oldEndDate = ((Label)(row.Cells[4].FindControl("myLabel6"))).Text;
            //Сохранение старых выбраных значений
            Session["oldClientName"] = oldClientName;
            Session["oldRoomNumber"] = oldRoomNumber;
            Session["oldHotelName"] = oldHotelName;
            Session["oldCountryName"] = oldCountryName;
            Session["oldStartDate"] = oldStartDate;
            Session["oldEndDate"] = oldEndDate;

            Session["operation"] = "Edit";
            Response.Redirect("MakeOrderForm.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ISession hbmSession = (ISession)Session["hbmsession"];
                DAOfactory factory = new NHibernateDAOFactory(hbmSession);
                var priceLabel = e.Row.FindControl("myLabel7") as Label;
                if(priceLabel!=null)
                {
                    var orderID= e.Row.FindControl("myLabel0") as Label;
                    IOrderDAO orderDAO = factory.getOrderDAO();
                    Order order = orderDAO.GetById(Convert.ToInt64(orderID.Text));
                    priceLabel.Text = (orderDAO.calculateFullPrice(order)*order.Room.Price).ToString();
                }
                var editCountryList = e.Row.FindControl("EditCountryList") as DropDownList;
                List<string> dataSource = factory.getCountryDAO().getCountryNames();
                if (editCountryList != null)
                {
                    editCountryList.DataSource = dataSource;
                    editCountryList.DataBind();
                    editCountryList.SelectedIndex = dataSource.IndexOf((string)ViewState["oldCountryName"]);
                }

            }
        }

        //Изменение номера текущей страницы
        protected void GridView1_PageIndexChanging(object sender,
          GridViewPageEventArgs e)
        {
            var GridView1 = sender as GridView;
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.EditIndex = -1;
            GridView1.ShowFooter = false;
            GridView1.DataBind();
        }

            protected void buttonMakeOrder_click(object sender, EventArgs e)
            {
                Session["operation"] = "Add";
                Response.Redirect("MakeOrderForm.aspx");
            }
        
    }
}