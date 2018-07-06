using Microsoft.AspNetCore.Mvc;
using WordCounterProject.Models;
using System;

namespace WordCounterProject.Controllers
{
    public class WordCounterController : Controller
    {
        [HttpGet("/word-counter")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("/word-counter/{word}/{phrase}")]
        public ActionResult Results(string word, string phrase)
        {
            WordCounter wordCount = new WordCounter(word, phrase);
            wordCount.RunWordCount();
            return View("Results", wordCount);
        }
    }
}
