using System.Web.Mvc;

namespace ConsultaUsuariosApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // Agregar el filtro VerificaSession globalmente
            // filters.Add(new VerificaSession()); // Descomenta si quieres aplicarlo globalmente
        }
    }
}