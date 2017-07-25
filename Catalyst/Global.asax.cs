using Catalyst.Db;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace Catalyst
{
    public class MvcApplication 
		: System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

			// force re-initialization of database
			//todo: may no longer be needed
			using (var db = new CatalystContext())
			{
				db.Database.Initialize(force: true);
			}
		}
    }
}
