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
    public partial class ClientForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            ISession session = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(session);
            IClientDAO clientDAO = factory.getClientDAO();
            List<Client> clients = clientDAO.GetAll();
            GridView1.DataSource = clients;
            GridView1.DataBind();
            //футер заполняется тут
            if (GridView1.FooterRow != null)
            {
                var footerCountryList = GridView1.FooterRow.FindControl("AddCountryList") as DropDownList;
                List<string> dataSource = factory.getCountryDAO().getCountryNames();
                dataSource.Add(" ");
                if (footerCountryList != null)
                {
                    footerCountryList.DataSource = dataSource;
                    footerCountryList.DataBind();
                    footerCountryList.SelectedIndex = dataSource.Count - 1;
                }
            }
            else {
                //заполняется пустой шаблон
                DropDownList emptyCountryDropDown = (DropDownList)GridView1.Controls[0].Controls[0].FindControl("EmptyCountryList");
                if (emptyCountryDropDown != null)
                {
                    //источник данных для списка
                    List<string> dataSource = factory.getCountryDAO().getCountryNames();
                    dataSource.Add(" ");
                    emptyCountryDropDown.DataSource = dataSource;
                    emptyCountryDropDown.DataBind();
                    emptyCountryDropDown.SelectedIndex = dataSource.Count - 1;
                }
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
            //Создаем DAO клиента
            ISession session = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(session);
            IClientDAO clientDAO = factory.getClientDAO();

            //Создаем обьект клиента
            Client client = new Client();
            client.Name = s1;
            client.Age = Convert.ToInt32(s2);
            client.Country = factory.getCountryDAO().getCountryByName(s3);

            clientDAO.SaveOrUpdate(client);
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        //Добавление первой записи в пустой GridView
        protected void ibInsertInEmpty_Click(object sender, EventArgs e)
        {
            var parent = ((Control)sender).Parent;
            var clientNameTextBox = parent
              .FindControl("emptyClientNameTextBox") as TextBox;
            var clientAgeTextBox = parent
              .FindControl("emptyClientAgeTextBox") as TextBox;
            var countryNameDropDown = parent
              .FindControl("EmptyCountryList") as DropDownList;

            ISession session = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(session);
            IClientDAO clientDAO = factory.getClientDAO();

            Client client = new Client();
            client.Name = clientNameTextBox.Text;
            client.Age = Convert.ToInt32(clientAgeTextBox.Text);
            client.Country = factory.getCountryDAO().getCountryByName(countryNameDropDown.SelectedValue);

            clientDAO.SaveOrUpdate(client);
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        //Удаление записи
        protected void GridView1_RowDeleting(object sender,
          GridViewDeleteEventArgs e)
        {
            //Получить индекс выделенной строки
            int index = e.RowIndex;
            GridViewRow row = GridView1.Rows[index];
            //Получить имя клиента
            string key = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;
            //Создание DAO клиента
            ISession hbmSession = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(hbmSession);
            IClientDAO hotelDAO = factory.getClientDAO();
            //Получение клиента по имени
            Client client = hotelDAO.getClientByName(key);
            //Удаление клиента
            if (client != null)
            {
                hotelDAO.Delete(client);
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
            string oldClientName = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;
            string oldCountryName = ((Label)(row.Cells[2].FindControl("myLabel3"))).Text;
            //Сохранение имени клиента в коллекции ViewState
            ViewState["oldClientName"] = oldClientName;
            ViewState["oldCountryName"] = oldCountryName;
            GridView1.EditIndex = index;
            GridView1.ShowFooter = false;
            GridView1.DataBind();
        }

        //заполняем список в шаблоне редактирования строки
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
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            GridViewRow row = GridView1.Rows[index];
            string newHotelName =
              ((TextBox)(row.Cells[0].FindControl("myTextBox1"))).Text;
            string newService =
              ((TextBox)(row.Cells[1].FindControl("myTextBox2"))).Text;
            string newCountryName =
              ((DropDownList)(row.Cells[2].FindControl("EditCountryList"))).SelectedValue;

            string oldClientName = (string)ViewState["oldClientName"];
            //Создание DAO клиента
            ISession hbmSession = (ISession)Session["hbmsession"];
            DAOfactory factory = new NHibernateDAOFactory(hbmSession);
            IClientDAO hotelDAO = factory.getClientDAO();
            //Получение клиента по имени
            Client client = hotelDAO.getClientByName(oldClientName);
            client.Name = newHotelName;
            client.Age = Convert.ToInt32(newService);
            client.Country = factory.getCountryDAO().getCountryByName(newCountryName);

            hotelDAO.SaveOrUpdate(client);
            GridView1.EditIndex = -1;
            GridView1.ShowFooter = true;
            GridView1.DataBind();
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