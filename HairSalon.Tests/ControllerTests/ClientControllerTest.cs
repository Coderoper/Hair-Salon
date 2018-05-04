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
//     public class ClientControllerTest
//     {
//       [TestMethod]
//         public void Index_ReturnsCorrectView_True()
//         {
//             //Arrange
//             ClientController controller = new ClientController();
//
//             //Act
//             ActionResult indexView = controller.Index();
//             //Assert
//             Assert.IsInstanceOfType(indexView, typeof(ViewResult));
//         }
//       [TestMethod]
//       public void Index_HasCorrectModelType_ClientList()
//       {
//           //Arrange
//           ViewResult indexView = new ClientController().Index() as ViewResult;
//
//           //Act
//           var result = indexView.ViewData.Model;
//           Console.Write("Model is: ");
//           Console.WriteLine(result);
//
//           //Assert
//           Assert.IsTrue(result.GetType() == typeof(List<Client>));
//           Assert.IsInstanceOfType(result, typeof(List<Client>));
//       }
//       // public ActionResult Index()
//       // {
//       //   return new EmptyResult();
//       // }
//     }
// }
