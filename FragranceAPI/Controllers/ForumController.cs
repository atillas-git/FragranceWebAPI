using Microsoft.AspNetCore.Mvc;

namespace FragranceAPI.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
