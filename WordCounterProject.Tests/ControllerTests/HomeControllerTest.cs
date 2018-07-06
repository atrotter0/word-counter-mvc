using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WordCounterProject.Controllers;
using WordCounterProject.Models;

namespace WordCounterProject.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            HomeController controller = new HomeController();
            ActionResult Index = controller.Index();
            Assert.IsInstanceOfType(Index, typeof(ViewResult));
        }

        [TestMethod]
        public void Contact_ReturnsCorrectView_True()
        {
            HomeController controller = new HomeController();
            ActionResult Contact = controller.Contact();
            Assert.IsInstanceOfType(Contact, typeof(ViewResult));
        }
    }
}
