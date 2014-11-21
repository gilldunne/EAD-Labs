using System.Web;
using System.Web.Mvc;

namespace MVCExercise2_StorageCalculator {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
