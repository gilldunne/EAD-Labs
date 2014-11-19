using System.Web;
using System.Web.Mvc;

namespace MVCExercise1_CloudServiceCalculator {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
