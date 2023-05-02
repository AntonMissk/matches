using Microsoft.AspNetCore.Mvc;

namespace MatchesGame_Web.Controllers
{
    public class Default : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
