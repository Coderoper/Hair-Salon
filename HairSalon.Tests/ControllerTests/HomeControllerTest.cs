// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using HairSalonApp.Controllers;
// using HairSalonApp.Models;
// using System;
//
// namespace HairSalonApp.Tests
// {
//     [TestClass]
//     public class HomeControllerTest
//     {
//       [TestMethod]
//         public void Index_ReturnsCorrectView_True()
//         {
//             //Arrange
//             HomeController controller = new HomeController();
//
//             //Act
//             ActionResult indexView = controller.Index();
//             //Assert
//             Assert.IsInstanceOfType(indexView, typeof(ViewResult));
//         }
//       [TestMethod]
//       public void Index_HasCorrectModelType_ItemList()
//       {
//           //Arrange
//           ViewResult indexView = new HomeController().Index() as ViewResult;
//
//           //Act
//           var result = indexView.ViewData.Model;
//           Console.Write("Model is: ");
//           Console.WriteLine(result);
//
//           //Assert
//           Assert.IsTrue(result.GetType() == typeof(List<Item>));
//           Assert.IsInstanceOfType(result, typeof(List<Item>));
//       }
//       // public ActionResult Index()
//       // {
//       //   return new EmptyResult();
//       // }
//     }
// }
