using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BakeryMenu.BreadMenu;
using BakeryMenu.PastryMenu;

namespace UserOrder.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    private static Bread _breadObject = new Bread(5, 10, 3);
    private static Pastry _pastryObject = new Pastry(2, 5, 3);
    private Order _orderObject = new Order(_breadObject, _pastryObject);

    public void Dispose()
    {
      _orderObject.ItemsList.Clear();
    }

    [TestMethod]
    public void AddItemToList_ZeroBread_ItemNotAddedToItemsList()
    {
      string itemType = "bread";
      int quantity = 0;

      bool isItemAdded = _orderObject.AddItemToList(itemType, quantity);
      Assert.IsFalse(isItemAdded);
      Assert.IsFalse(_orderObject.ItemsList.ContainsKey(itemType));
    }

    [TestMethod]
    public void AddItemToList_OneBread_ItemsListWithBreadQuantityOneLinePriceFive()
    {
      string itemType = "bread";
      int quantity = 1;

      decimal expectedLinePrice = 5;
      object[] expectedItemValues = new object[] {quantity, expectedLinePrice, _orderObject.BreadObject};

      bool isItemAdded = _orderObject.AddItemToList(itemType, quantity);
      Assert.IsTrue(isItemAdded);
      Assert.IsTrue(_orderObject.ItemsList.ContainsKey(itemType));
      CollectionAssert.AreEqual(expectedItemValues, _orderObject.ItemsList[itemType]);
    }

    [TestMethod]
    public void AddItemToList_PastryTwice_ItemsListCountOne()
    {
      string itemType = "pastry";
      int quantity = 1;

      int expectedQuantity = 2;
      decimal expectedLinePrice = 4;
      int expectedItemsListCount = 1;
      object[] expectedItemValues = new object[] {expectedQuantity, expectedLinePrice, _orderObject.PastryObject};

      bool isItemAddedFirstTime = _orderObject.AddItemToList(itemType, quantity);
      bool isItemAddedSecondTime = _orderObject.AddItemToList(itemType, quantity);
      Assert.IsTrue(isItemAddedFirstTime);
      Assert.IsTrue(isItemAddedSecondTime);
      Assert.IsTrue(_orderObject.ItemsList.ContainsKey(itemType));
      Assert.AreEqual(expectedItemsListCount, _orderObject.ItemsList.Count);
      CollectionAssert.AreEqual(expectedItemValues, _orderObject.ItemsList[itemType]);
    }

    [TestMethod]
    public void GetTotalCost_NoItems_Zero()
    {
      decimal expectedTotal = 0;
      decimal returnedTotal = _orderObject.GetTotalCost();
      Assert.AreEqual(expectedTotal, returnedTotal);
    }

    [TestMethod]
    public void GetTotalCost_FourBreadFivePastry_TwentyFour()
    {
      decimal expectedTotal = 24;
      _orderObject.AddItemToList("bread", 4);
      _orderObject.AddItemToList("pastry", 5);
      decimal returnedTotal = _orderObject.GetTotalCost();
      Assert.AreEqual(expectedTotal, returnedTotal);
    }
  }
}