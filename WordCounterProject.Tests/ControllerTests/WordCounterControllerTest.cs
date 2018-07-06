using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WordCounterProject.Controllers;
using WordCounterProject.Models;

namespace WordCounterProject.Tests
{
    [TestClass]
    public class WordCounterControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            WordCounterController controller = new WordCounterController();
            ActionResult Index = controller.Index();
            Assert.IsInstanceOfType(Index, typeof(ViewResult));
        }

        [TestMethod]
        public void Results_ReturnsCorrectView_True()
        {
            WordCounterController controller = new WordCounterController();
            ActionResult Results = controller.Results("word", "word in a phrase");
            Assert.IsInstanceOfType(Results, typeof(ViewResult));
        }

        [TestMethod]
        public void Results_HasCorrectModelType_WordCounter()
        {
            ViewResult Results = new WordCounterController().Results("word", "word in a phrase") as ViewResult;
            var result = Results.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(WordCounter));
        }

        [TestMethod]
        public void PostResults_ReturnsCorrectView_True()
        {
            WordCounterController controller = new WordCounterController();
            ActionResult PostResults = controller.PostResults("word", "word in a phrase");
            Assert.IsInstanceOfType(PostResults, typeof(ViewResult));
        }

        [TestMethod]
        public void PostResults_HasCorrectModelType_WordCounter()
        {
            ViewResult PostResults = new WordCounterController().PostResults("word", "word in a phrase") as ViewResult;
            var result = PostResults.ViewData.Model;
            Assert.IsInstanceOfType(result, typeof(WordCounter));
        }
    }
}
