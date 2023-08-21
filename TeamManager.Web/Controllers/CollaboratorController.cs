using Microsoft.AspNetCore.Mvc;

namespace TeamManager.Web.Controllers
{
    public class CollaboratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
