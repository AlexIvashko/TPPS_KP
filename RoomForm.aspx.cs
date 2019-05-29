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
    public partial class RoomForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            string keyHotel = (string)Session["keyHotelName"];
            hotelLabel.Text = "Кімнати готелю " + keyHotel;
            ISession session = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(session);
            IHotelDAO hotelDAO = factory.getHotelDAO();
            IList<Room> Rooms = hotelDAO.getAllRooms(keyHotel);
            GridView1.DataSource = Rooms;
            GridView1.DataBind();
            if (Rooms.Count>0)
            {
                var footerTypesList = GridView1.FooterRow.FindControl("AddTypesList") as DropDownList;
                if (footerTypesList != null)
                {
                    List<string> dataSource = new List<string> { "Стандарт", "Напівлюкс", "Люкс", " " };
                    footerTypesList.DataSource = dataSource;
                    footerTypesList.DataBind();
                    footerTypesList.SelectedIndex = dataSource.Count - 1;
                }
            }
            else
            {
                var EmptyTypesList = GridView1.Controls[0].Controls[0].FindControl("emptyTypesList") as DropDownList;
                if (EmptyTypesList != null)
                {
                    List<string> dataSource = new List<string> { "Стандарт", "Напівлюкс", "Люкс", " " };
                    EmptyTypesList.DataSource = dataSource;
                    EmptyTypesList.DataBind();
                    EmptyTypesList.SelectedIndex = dataSource.Count - 1;
                }
            }

            bool isVisible = (User.IsInRole("Administrator") | User.IsInRole("Supervisor"));
            GridView1.FooterRow.Visible = isVisible;
            GridView1.Columns[4].Visible = isVisible;

        }

        protected void Page_Preload(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var editTypesList = e.Row.FindControl("EditTypesList") as DropDownList;

              if (editTypesList != null)
              {
                    List<string> dataSource = new List<string>() { "Стандарт", "Напівлюкс", "Люкс" };
                    editTypesList.DataSource = dataSource;
                    editTypesList.DataBind();
                    editTypesList.SelectedIndex = dataSource.IndexOf((string)ViewState["oldRoomType"]);
               }
            }
        }

        protected void ibInsert_Click(object sender, EventArgs e)
        {
            string keyHotel = (string)Session["keyHotelName"];
            //Получаем значения полей
            string s1 =
              ((TextBox)GridView1.FooterRow.FindControl("MyFooterTextBox1")).Text;
            string s2 =
              ((DropDownList)GridView1.FooterRow.FindControl("AddTypesList")).SelectedValue;
            string s3 =
              ((TextBox)GridView1.FooterRow.FindControl("MyFooterTextBox3")).Text;
            string s4 =
              ((TextBox)GridView1.FooterRow.FindControl("MyFooterTextBox4")).Text;

            //Создаем сессию
            ISession session = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(session);
            IHotelDAO hotelDAO = factory.getHotelDAO();
            Hotel hotel = hotelDAO.getHotelByName(keyHotel);
            IRoomDAO roomDAO = factory.getRoomDAO();

            //Создаем объект комнаты и заполняем его поля
            Room room = new Room();
            room.Number = Convert.ToInt32(s1);
            room.Type = s2;
            room.Size = Convert.ToInt32(s3);
            room.Price = Convert.ToInt32(s4);

            room.Hotel = hotel;
            hotel.RoomList.Add(room);

            //Сохраняем объект комнаты
            roomDAO.SaveOrUpdate(room);
           Response.Redirect(HttpContext.Current.Request.Url.ToString());           
        }

        protected void ibInsertInEmpty_Click(object sender, EventArgs e)
        {
            string keyHotel = (string)Session["keyHotelName"];
            //Получаем значения полей ввода
            var parent = ((Control)sender).Parent;
            var numberTextBox = parent
              .FindControl("emptyNumberTextBox") as TextBox;
            var typeDropDown = parent
              .FindControl("emptyTypesList") as DropDownList;
            var sizeTextBox = parent.FindControl("emptySizeTextBox") as TextBox;
            var priceTextBox = parent.FindControl("emptyPriceTextBox") as TextBox;

            //Создаем сессию
            ISession session = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(session);

            IHotelDAO hotelDAO = factory.getHotelDAO();
            Hotel hotel = hotelDAO.getHotelByName(keyHotel);
            IRoomDAO roomDAO = factory.getRoomDAO();

            //Создаем объект комнаты и заполняем его поля
            Room room = new Room();
            room.Number = Convert.ToInt32(numberTextBox.Text);
            room.Type = typeDropDown.SelectedValue;
            if (sizeTextBox.Text == "")
                sizeTextBox.Text = "?";
            room.Size = Convert.ToInt32(sizeTextBox.Text);
            room.Price = Convert.ToInt32(priceTextBox.Text);
            room.Hotel = hotel;

            hotel.RoomList.Add(room);

            //Сохраняем объект комнаты
            roomDAO.SaveOrUpdate(room);
                Response.Redirect(HttpContext.Current.Request.Url.ToString());           
        }

        //Удаление строки
        protected void GridView1_RowDeleting(object sender,
          GridViewDeleteEventArgs e)
        {
            string keyHotel = (string)Session["keyHotelName"];
            //Получить индекс выделенной строки
            int index = e.RowIndex;
            GridViewRow row = GridView1.Rows[index];
            //Получить номер комнаты
            string number = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;          
            ISession hbmSession = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(hbmSession);
            IRoomDAO roomDAO = factory.getRoomDAO();

            Room room =
              roomDAO.getRoomByHotelAndNumber(keyHotel, number);

            //Удаление комнаты
            if (room != null)
            {
                room.Hotel.RoomList.Remove(room);
                roomDAO.Delete(room);
            }
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        //Перевод строки в режим редактирования
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Получить индекс выделенной строки
            int index = e.NewEditIndex;
            GridViewRow row = GridView1.Rows[index];
            //Получение старых значений полей в строке GridView
            string oldNumber = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;
            string oldType = ((Label)(row.Cells[1].FindControl("myLabel2"))).Text;
            //Сохранение номер комнаты в коллекции ViewState
            ViewState["oldRoomNumber"] = oldNumber;
            ViewState["oldRoomType"] = oldType;
            GridView1.EditIndex = index;
            GridView1.ShowFooter = false;
            GridView1.DataBind();
        }

        //Отмена редактирования строки
        protected void GridView1_RowCancelingEdit(object sender,
          GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.ShowFooter = true;
            GridView1.DataBind();
        }

        //Редактирование строки
        protected void GridView1_RowUpdating(object sender,
          GridViewUpdateEventArgs e)
        {
            string keyHotel = (string)Session["keyHotelName"];
            int index = e.RowIndex;
            GridViewRow row = GridView1.Rows[index];
            string newNumber =
              ((TextBox)(row.Cells[0].FindControl("myTextBox1"))).Text;
            string newType =
              ((DropDownList)(row.Cells[1].FindControl("EditTypesList"))).SelectedValue;
            string newSize = ((TextBox)(row.Cells[2].FindControl("myTextBox3"))).Text;
            string newPrice = ((TextBox)(row.Cells[3].FindControl("myTextBox4"))).Text;


            string oldNumber = (string)ViewState["oldRoomNumber"];

            //Создание DAO комнаты
            ISession hbmSession = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(hbmSession);
            IRoomDAO roomDAO = factory.getRoomDAO();

            //Получение отдела по названию
            Room room =
              roomDAO.getRoomByHotelAndNumber(keyHotel,oldNumber);
            room.Number = Convert.ToInt32(newNumber);
            room.Type = newType;
            room.Size = Convert.ToInt32(newSize);
            room.Price = Convert.ToInt32(newPrice);

            roomDAO.SaveOrUpdate(room);
            GridView1.EditIndex = -1;
            GridView1.ShowFooter = true;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.EditIndex = -1;
            GridView1.ShowFooter = true;
            GridView1.DataBind();
        }
    }
}