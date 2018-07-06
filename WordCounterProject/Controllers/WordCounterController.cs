using Microsoft.AspNetCore.Mvc;
using WordCounterProject.Models;

namespace WordCounterProject.Controllers
{
    public class WordCounterController : Controller
    {
        [HttpGet("/play-word-counter")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
