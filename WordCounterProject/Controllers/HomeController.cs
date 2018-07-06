using Microsoft.AspNetCore.Mvc;
using WordCounterProject.Models;

namespace WordCounterProject.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
