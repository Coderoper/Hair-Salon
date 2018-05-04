using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalonApp.Models;
using System.Collections.Generic;
using System;



namespace HairSalonApp.Tests
{

    [TestClass]
    public class ClientTests : IDisposable
    {
        public void Dispose()
        {
            Client.DeleteAll();
        }
        public ClientTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=todo_test;";
        }
        // [TestMethod]
        // public void GetAll_DbStartsEmpty_0()
        // {
        //   //Arrange
        //   //Act
        //   int result = Client.GetAll().Count;
        //
        //   //Assert
        //   Assert.AreEqual(0, result);
        // }
        // [TestMethod]
        // public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Client()
        // {
        //   // Arrange, Act
        //   Client firstClient = new Client("Mow the lawn");
        //   Client secondClient = new Client("Mow the lawn");
        //
        //   // Assert
        //   Assert.AreEqual(firstClient, secondClient);
        // }
        // [TestMethod]
        // public void Save_SavesToDatabase_ClientList()
        // {
        //   //Arrange
        //   Client testClient = new Client("Mow the lawn");
        //
        //   //Act
        //   testClient.Save();
        //   List<Client> result = Client.GetAll();
        //   Console.WriteLine(result.Count);
        //   foreach(Client element in result)
        //   {
        //     Console.WriteLine("result: " + result);
        //   }
        //
        //
        //   List<Client> testList = new List<Client>{testClient};
        //   Console.WriteLine(testList.Count);
        //   Console.WriteLine("testClient "+testClient);
        //   Console.WriteLine("testList " +testList);
        //   //Assert
        //   CollectionAssert.AreEqual(testList, result);
        // }

        [TestMethod]
        public void Save_AssignsIdToObject_Id()
        {
          //Arranges
          Client testClient = new Client("Mow the lawn");

          //Act
          testClient.Save();
          Client savedClient = Client.GetAll()[0];

          int result = savedClient.GetId();
          int testId = testClient.GetId();

          Console.WriteLine("testId: " + testId);
          Console.WriteLine("result: " + result);
          //Assert
          Assert.AreEqual(testId, result);
        }
        [TestMethod]
        public void Find_FindsClientInDatabase_Client()
        {
          //Arrange
          Client testClient = new Client("Mow the lawn");
          testClient.Save();

          //Act
          Client foundClient = Client.Find(testClient.GetId());

          //Assert
          Assert.AreEqual(testClient, foundClient);
        }

    }
}
