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
    public partial class HotelForm : System.Web.UI.Page
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
            GridView1.DataSource = hotels;
            GridView1.DataBind();
            if (hotels.Count > 0)
            {
                var footerCountryList = GridView1.FooterRow.FindControl("AddCountryList") as DropDownList;
                List<string> dataSource = factory.getCountryDAO().getCountryNames();
                dataSource.Add(" ");
                footerCountryList.DataSource = dataSource;
                footerCountryList.DataBind();
                footerCountryList.SelectedIndex = dataSource.Count - 1;
            }
            else
            {
                var emptyCountryList = GridView1.Controls[0].Controls[0].FindControl("EmptyCountryList") as DropDownList;
                List<string> dataSource = factory.getCountryDAO().getCountryNames();
                dataSource.Add(" ");
                emptyCountryList.DataSource = dataSource;
                emptyCountryList.DataBind();
                emptyCountryList.SelectedIndex = dataSource.Count - 1;
            }
        }

        //Обработчик нажатия на добавить
        protected void ibInsert_Click(object sender, EventArgs e)
        {
            //Получаем значения полей
            string s1 =
              ((TextBox)GridView1.FooterRow.FindControl("MyFooterTextBox1")).Text;
            string s2 =
              ((TextBox)GridView1.FooterRow.FindControl("MyFooterTextBox2")).Text;
            string s3 =
              ((DropDownList)GridView1.FooterRow.FindControl("AddCountryList")).SelectedValue;
            //Создаем DAO отеля
            ISession session = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(session);
            IHotelDAO hotelDAO = factory.getHotelDAO();

            //Создаем hotel
            Hotel hotel = new Hotel();
            hotel.Name = s1;
            hotel.Service = Convert.ToInt32(s2);
            hotel.Country = factory.getCountryDAO().getCountryByName(s3);

            hotelDAO.SaveOrUpdate(hotel);
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        //Добавление первой записи в пустой GridView
        protected void ibInsertInEmpty_Click(object sender, EventArgs e)
        {
            var parent = ((Control)sender).Parent;
            var hotelNameTextBox = parent
              .FindControl("emptyGroupNameTextBox") as TextBox;
            var serviceTextBox = parent
              .FindControl("emptyCuratorNameTextBox") as TextBox;
            var countryNameDropDown = parent
              .FindControl("EmptyCountryList") as DropDownList;
                      
            ISession session = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(session);
            IHotelDAO hotelDAO = factory.getHotelDAO();

            Hotel hotel = new Hotel();
            hotel.Name = hotelNameTextBox.Text;
            hotel.Service = Convert.ToInt32(serviceTextBox.Text);
            hotel.Country = factory.getCountryDAO().getCountryByName(countryNameDropDown.SelectedValue);

            hotelDAO.SaveOrUpdate(hotel);
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        //Удаление записи
        protected void GridView1_RowDeleting(object sender,
          GridViewDeleteEventArgs e)
        {
            //Получить индекс выделенной строки
            int index = e.RowIndex;
            GridViewRow row = GridView1.Rows[index];
            //Получить название отеля
            string key = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;
            //Создание DAO отеля
            ISession hbmSession = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(hbmSession);
            IHotelDAO hotelDAO = factory.getHotelDAO();
            //Получение отеля по имени
            Hotel hotel = hotelDAO.getHotelByName(key);
            //Удаление отеля
            if (hotel != null)
            {
                hotelDAO.Delete(hotel);
            }
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        //Перевести строку в режим редактирования
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Получить индекс выделенной строки
            int index = e.NewEditIndex;
            GridViewRow row = GridView1.Rows[index];
            //Получение старых значений полей в строке GridView
            string oldHotelName = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;
            string oldCountryName = ((Label)(row.Cells[2].FindControl("myLabel3"))).Text;
            //Сохранение названия отеля в коллекции ViewState
            ViewState["oldHotelName"] = oldHotelName;
            ViewState["oldCountryName"] = oldCountryName;
            GridView1.EditIndex = index;
            GridView1.ShowFooter = false;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var editCountryList = e.Row.FindControl("EditCountryList") as DropDownList;             
                ISession hbmSession = (ISession)Session["hbmsession"];
                DAOfactory factory = new NHibernateDAOFactory(hbmSession);
                List<string> dataSource = factory.getCountryDAO().getCountryNames();
                if (editCountryList != null)
                {
                    editCountryList.DataSource = dataSource;
                    editCountryList.DataBind();
                    editCountryList.SelectedIndex = dataSource.IndexOf((string)ViewState["oldCountryName"]);
                }

            }
        }

        //Отмена редактирования записи
        protected void GridView1_RowCancelingEdit(object sender,
          GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.ShowFooter = true;
            GridView1.DataBind();
        }

        //Редактирование строки
        protected void GridView1_RowUpdating(object sender,GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            GridViewRow row = GridView1.Rows[index];
            string newHotelName =
              ((TextBox)(row.Cells[0].FindControl("myTextBox1"))).Text;
            string newService =
              ((TextBox)(row.Cells[1].FindControl("myTextBox2"))).Text;
            string newCountryName =
              ((DropDownList)(row.Cells[2].FindControl("EditCountryList"))).SelectedValue;

            string oldHotelName = (string)ViewState["oldHotelName"];
            //Создание DAO отеля
            ISession hbmSession = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(hbmSession);
            IHotelDAO hotelDAO = factory.getHotelDAO();
            //Получение отеля по имени
            Hotel hotel = hotelDAO.getHotelByName(oldHotelName);
            hotel.Name = newHotelName;
            hotel.Service = Convert.ToInt32(newService);
            hotel.Country = factory.getCountryDAO().getCountryByName(newCountryName);

            hotelDAO.SaveOrUpdate(hotel);
            GridView1.EditIndex = -1;
            GridView1.ShowFooter = true;
            GridView1.DataBind();
        }

        //Вывод списка всех комнат
        protected void GridView1_RowCommand(object sender,
          GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string hotelName = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;
                Session["keyHotelName"] = hotelName;
                Response.Redirect("RoomForm.aspx");
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

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            bool isAdmin = User.IsInRole("Administrator");
            bool isSupervisor = User.IsInRole("Supervisor");
            if (isAdmin || isSupervisor)
            {
                GridView1.FooterRow.Visible = true;
            }
            else
            {
                GridView1.FooterRow.Visible = false;
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && 
                e.Row.RowIndex != GridView1.EditIndex)
            {
                // Programmatically reference the Edit and Delete LinkButtons
                Button EditButton = e.Row.FindControl("ibEdit") as Button;

                Button DeleteButton = e.Row.FindControl("ibDelete") as Button;

                EditButton.Visible = (User.IsInRole("Administrator") || User.IsInRole("Supervisor"));
                DeleteButton.Visible = User.IsInRole("Administrator");
            }
        }

    }
}