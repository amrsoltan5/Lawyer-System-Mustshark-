using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Project_Faculty.Models;
using System.Web.SessionState;

namespace Project_Faculty
{
    public class MvcApplication : System.Web.HttpApplication
    {
        project13 db = new project13();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

       protected void Session_Start(object sender, EventArgs e)

        {
            
            
              
        }



        protected void Session_End(object sender, EventArgs e)
        {
            

                var sessionid = this.Session.SessionID;
                var data = db.lawyers.SingleOrDefault(a => a.session_id == sessionid);

                if(data != null)
           {

                data.session_id = null;
                db.SaveChanges();
                var connectionlawyer = db.Connections.Where(a => a.lawyer_id == data.id).SingleOrDefault();
                if (connectionlawyer != null)
                {

                    connectionlawyer.connectionId = null;
                    connectionlawyer.lawyer_id = null;
                    db.SaveChanges();

                }

          }


               

           
        }
    }
}
