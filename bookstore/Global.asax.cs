using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace bookstore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new BookStoreContextInitializer());
        }
    }
    public class BookStoreContextInitializer : DropCreateDatabaseIfModelChanges<BookStoreContext>
    {
        protected override void Seed(BookStoreContext context)
        {
            base.Seed(context);
            context.Authors.Add(new AuthorViewModel() { Name = "Marco Bothon" });
            context.Authors.Add(new AuthorViewModel() { Name = "Paulo Coelho" });
            context.Authors.Add(new AuthorViewModel() { Name = "Valeri Liberty" });
            context.Authors.Add(new AuthorViewModel() { Name = "Carlos D Mesa" });
            context.Authors.Add(new AuthorViewModel() { Name = "Montserrat Mira" });
            context.SaveChanges();
        }
    }
}
