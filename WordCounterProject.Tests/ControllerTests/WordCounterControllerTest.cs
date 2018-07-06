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
    }
}
