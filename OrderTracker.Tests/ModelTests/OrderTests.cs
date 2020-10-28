using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderTracker.Models;
using System.Collections.Generic;
using System;

namespace OrderTracker.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("test", "test1", "test2", "test3", "test4");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";
      string quantity = "3";
      string price = "4";
      string dateOrdered = "10/01/2020";
      string dateShipped = "10/02/2020";
      Order newOrder = new Order(description, quantity, price, dateOrdered, dateShipped);

      //Act
      string result = newOrder.Item;

      //Assert
      Assert.AreEqual(description, result);
    } 

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      // Arrange
      string description = "Walk the dog.";
      string quantity = "3";
      string price = "4";
      string dateOrdered = "10/01/2020";
      string dateShipped = "10/02/2020";
      Order newOrder = new Order(description, quantity, price, dateOrdered, dateShipped);
      // Act
      string updatedDescription = "Do the dishes";
      newOrder.Item = updatedDescription;
      string result = newOrder.Item;
      // Assert
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      // Arrange
      List<Order> newList = new List<Order> { };
      // Act
      List<Order> result = Order.GetAll();
      // Assert
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void GetAll_ReturnsOrders_OrderLIst()
    {
      // Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      string quantity = "3";
      string price = "4";
      string dateOrdered = "10/01/2020";
      string dateShipped = "10/02/2020";
      Order newOrder1 = new Order(description01, quantity, price, dateOrdered, dateShipped);
      Order newOrder2 = new Order(description02, quantity, price, dateOrdered, dateShipped);
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };
      // Act
      List<Order> result = Order.GetAll();
      // Assert
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void GetId_OrdersInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      string description = "Walk the dog.";
      string quantity = "3";
      string price = "4";
      string dateOrdered = "10/01/2020";
      string dateShipped = "10/02/2020";
      Order newOrder = new Order(description, quantity, price, dateOrdered, dateShipped);

      //Act
      int result = newOrder.Id;

      //Assert
      Assert.AreEqual(1, result);
    }
    
    [TestMethod]
    public void Find_ReturnsCorrectOrder_Order()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      string quantity = "3";
      string price = "4";
      string dateOrdered = "10/01/2020";
      string dateShipped = "10/02/2020";
      Order newOrder1 = new Order(description01, quantity, price, dateOrdered, dateShipped);
      Order newOrder2 = new Order(description02, quantity, price, dateOrdered, dateShipped);

      //Act
      Order result = Order.Find(2);

      //Assert
      Assert.AreEqual(newOrder2, result);
    }
  }
}