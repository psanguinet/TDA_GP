using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Security;
using System.Data.Linq;
using System.Web.Routing;



namespace DataAccess.Model
{
    public class DBInitializer : DropCreateDatabaseAlways<Context>
    {

        protected override void Seed(Context context)
        {
            WebSecurity.Register("Demo", "123456", "demo@demo.com", true, "Demo", "Demo");
            Roles.CreateRole("Admin");
            Roles.AddUserToRole("Demo", "Admin");
            base.Seed(context);
        }
    }
    }