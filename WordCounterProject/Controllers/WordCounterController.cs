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
            WordCounter newWord = new WordCounter();
            newWord.SetUserWord(word);
            newWord.SetUserPhrase(phrase);
            newWord.RunWordCount();
            return View(newWord);
        }
    }
}
