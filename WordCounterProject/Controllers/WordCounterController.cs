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

        public ActionResult Results(string word, string phrase)
        {
            WordCounter word = new WordCounter();
            word.RunWordCount();
            return View(word);
        }
    }
}
