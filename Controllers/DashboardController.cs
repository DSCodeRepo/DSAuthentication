using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Authorize]
    public class DashboardController : Controller
    {
         private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        // GET: DashboardController
        public ActionResult Index()
        {
            return View();
        }

    }
}
