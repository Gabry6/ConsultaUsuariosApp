// Añade esta línea al principio para poder usar tu nuevo inicializador

using System.Data.Entity; // Asegúrate de que esta línea también exista
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ConsultaUsuariosApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

          
        }
    }
}
