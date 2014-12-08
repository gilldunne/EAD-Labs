using System.Web;
using System.Web.Mvc;

namespace CA3_SampleWork {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
