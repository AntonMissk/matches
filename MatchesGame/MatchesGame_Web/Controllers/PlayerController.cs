using Microsoft.AspNetCore.Mvc;

namespace MatchesGame_Web.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
