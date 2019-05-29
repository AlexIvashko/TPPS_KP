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
    public partial class CountryForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

    protected void Page_Prerender(object sender, EventArgs e)
    {
        ISession session = (ISession)Session["hbmsession"];
        DAOfactory factory = new NHibernateDAOFactory(session);
        ICountryDAO countryDAO = factory.getCountryDAO();
        List<Country> departments = countryDAO.GetAll();
        GridView1.DataSource = departments;
        GridView1.DataBind();
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
          ((TextBox)GridView1.FooterRow.FindControl("MyFooterTextBox3")).Text;
        string s4 =
          ((TextBox)GridView1.FooterRow.FindControl("MyFooterTextBox4")).Text;
        string s5 =
          ((TextBox)GridView1.FooterRow.FindControl("MyFooterTextBox5")).Text;

            //Создаем country
            Country country = new Country();
            country.Name = s1;
            country.Capital = s2;
            country.Language = s3;
            country.Currency = s4;
            country.Religion = s5;
        //Создаем DAO страны
        ISession session = (ISession)Session["hbmsession"];
        DAOfactory factory = new NHibernateDAOFactory(session);
        ICountryDAO countryDAO = factory.getCountryDAO();
        countryDAO.SaveOrUpdate(country);
        Response.Redirect(HttpContext.Current.Request.Url.ToString());
    }

    //Добавление первой записи в пустой GridView
    protected void ibInsertInEmpty_Click(object sender, EventArgs e)
    {
        var parent = ((Control)sender).Parent;
        var countryNameTextBox = parent
          .FindControl("emptyNameTextBox") as TextBox;
        var capitalTextBox = parent
          .FindControl("emptyCapitalTextBox") as TextBox;
        var languageTextBox = parent
          .FindControl("emptyLanguageTextBox") as TextBox;
        var currrencyTextBox = parent
            .FindControl("emptyCurrencyTextBox") as TextBox;
        var religionTextBox = parent
            .FindControl("emptyReligionTextBox") as TextBox;
            Country country = new Country();
            country.Name = countryNameTextBox.Text;
            country.Capital = capitalTextBox.Text;
            country.Language = languageTextBox.Text;
            country.Currency = currrencyTextBox.Text;
            country.Religion = religionTextBox.Text;
        ISession session = (ISession)Session["hbmsession"];
        DAOfactory factory = new NHibernateDAOFactory(session);
        ICountryDAO countryDAO = factory.getCountryDAO();
        countryDAO.SaveOrUpdate(country);
        Response.Redirect(HttpContext.Current.Request.Url.ToString());
    }

    //Удаление записи
    protected void GridView1_RowDeleting(object sender,
      GridViewDeleteEventArgs e)
    {
        //Получить индекс выделенной строки
        int index = e.RowIndex;
        GridViewRow row = GridView1.Rows[index];
        //Получить название страны
        string key = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;
            //Создание DAO страны
            ISession hbmSession = (ISession)Session["hbmsession"];
        DAOfactory factory = new NHibernateDAOFactory(hbmSession);
        ICountryDAO countryDAO = factory.getCountryDAO();
            //Получение страны по названию
            Country country = countryDAO.getCountryByName(key);
            //Удаление страны
            if (country != null)
        {
            countryDAO.Delete(country);
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
        string oldCountryName = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;
        //Сохранение названия группы в коллекции ViewState
        ViewState["oldCountryName"] = oldCountryName;
        GridView1.EditIndex = index;
        GridView1.ShowFooter = false;
        GridView1.DataBind();
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
    protected void GridView1_RowUpdating(object sender,
      GridViewUpdateEventArgs e)
    {
        int index = e.RowIndex;
        GridViewRow row = GridView1.Rows[index];
        string newCountryName =
          ((TextBox)(row.Cells[0].FindControl("myTextBox1"))).Text;
        string newCapital =
          ((TextBox)(row.Cells[1].FindControl("myTextBox2"))).Text;
        string newLanguage =
          ((TextBox)(row.Cells[2].FindControl("myTextBox3"))).Text;
        string newCurrency =
            ((TextBox)(row.Cells[3].FindControl("myTextBox4"))).Text;
        string newReligion =
            ((TextBox)(row.Cells[2].FindControl("myTextBox5"))).Text;

        string oldCountryName = (string)ViewState["oldCountryName"];
        //Создание DAO 
        ISession hbmSession = (ISession)Session["hbmsession"];
        DAOfactory factory = new NHibernateDAOFactory(hbmSession);
        ICountryDAO countryDAO = factory.getCountryDAO();
            //Получение страны по назвнию
            Country country = countryDAO.getCountryByName(oldCountryName);
            country.Name = newCountryName;
            country.Capital = newCapital;
            country.Language = newLanguage;
            country.Currency = newCurrency;
            country.Religion = newReligion;
        countryDAO.SaveOrUpdate(country);
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

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            bool isAdmin = User.IsInRole("Administrator");
            bool isSupervisor = User.IsInRole("Supervisor");
            if (isAdmin || isSupervisor)
            {
                GridView1.Columns[5].Visible = true;
                GridView1.FooterRow.Visible = true;
            }
            else
            {
                GridView1.Columns[5].Visible = false;
                GridView1.FooterRow.Visible = false;
            }
        }
    }
}