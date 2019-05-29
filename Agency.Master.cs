using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Reflection;
using System.Web;

namespace travel_agency
{
    public partial class Agency : System.Web.UI.MasterPage
    {
        private ISessionFactory factory;
        private ISession session;

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            //connection to database
            session = openSession("localhost","travel_agency", "root", "1101");
            Session["hbmsession"] = session;
        }

        protected void SignOut(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("~/Logout.aspx");
            //Server.Transfer("~/Account/Logout.aspx");
        }

        //Метод открытия сессии
        private ISession openSession(string host, string database,
          string user, string passwd)
        {
            ISession session = null;
            //Получение ссылки на текущую сборку
            Assembly mappingsAssemly = Assembly.GetExecutingAssembly();
            if (factory == null)
            {
                //Конфигурирование фабрики сессий
                factory = Fluently.Configure().Database(MySQLConfiguration.Standard
                   .ConnectionString(c => c.Server(host)
                   .Database(database)
                   .Username(user)
                   .Password(passwd)))
                   .Mappings(m => m.FluentMappings
                   .AddFromAssembly(mappingsAssemly))
                   //.ExposeConfiguration(BuildSchema)
                   .BuildSessionFactory();
            }
            //Открытие сессии
            session = factory.OpenSession();
            return session;
        }

        //Метод для автоматического создания таблиц в базе данных
        private static void BuildSchema(Configuration config)
        {
            //new SchemaExport(config).Create(false, true);
        }

   }
}