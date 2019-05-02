using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebVLTea.Controllers;
using WebVLTea.Models;
using System.Linq;

namespace WebVLTea.Tests.Controllers
{
    [TestClass]
    public class UnitTestController
    {
        
        [TestMethod]
        public void TestIndex()
        {
            var db = new CS4PEEntities();
            var controller = new ManagementTeaController();
            var result = controller.Index();
            var view = result as ViewResult;
            Assert.IsNotNull(view);
            var model = view.Model as List<BubleTea>;
            Assert.IsNotNull(model);
            Assert.AreEqual(db.BubleTeas.Count(), model.Count);


        }
        [TestMethod]
        public void TestCreate()
        {
            var controller = new ManagementTeaController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestCreateP()
        {
            var db = new CS4PEEntities();
            var model = new BubleTea
            {
                Name = "Tra sua VL",
                Price = 25000,
                Topping = " Chan chau den"

            };
            var controller = new ManagementTeaController();
            var item = db.BubleTeas.Find(model.id);
            Assert.IsNotNull(item);
            Assert.AreEqual(model.Name, item.Name);
            Assert.AreEqual(model.Price, item.Price);
            Assert.AreEqual(model.Topping, item.Topping);
            var result = controller.Create(model);

            var redirect = result as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);

        } 
        [TestMethod]
        public void TestDetails()
        {
            var controller = new ManagementTeaController();
            var result0 = controller.Details(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));
            var db = new CS4PEEntities();
            var item = db.BubleTeas.First();
            var result1 = controller.Details(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as BubleTea;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);

        }

        [TestMethod]
        public void TestEditG()
        {
            var controller = new ManagementTeaController();            
            var result0 = controller.Edit(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));
            var db = new CS4PEEntities();
            var item = db.BubleTeas.First();
            var result1 = controller.Edit(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as BubleTea;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);
        }
        [TestMethod]
        public void TestEditP()
        {
            var db = new CS4PEEntities();
            var controller = new ManagementTeaController();
            var item = db.BubleTeas.First();
            var result1 = controller.Edit(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as BubleTea;
            Assert.IsNotNull(model);
            var result = controller.Edit(model);
            var redirect = result as RedirectToRouteResult;

            Assert.IsNotNull(redirect);

            Assert.AreEqual("Index", redirect.RouteValues["action"]);

        }
        [TestMethod]
        public void TestDeleteGet()
        {
            var controller = new ManagemanetController();
            var result0 = controller.Delete(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));
            var db = new CS4PEEntities();
            var item = db.BubleTeas.First();
            var result1 = controller.Delete(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as BubleTea;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);

        }

        [TestMethod]
        public void TestDeletePost()
        {
            // Không thể tìm được models

        }

    }
}
