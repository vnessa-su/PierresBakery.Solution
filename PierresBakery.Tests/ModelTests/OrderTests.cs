using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserOrder.Tests
{
  [TestClass]
  public class OrderTests
  {
    Order _orderObject = new Order();

    [TestMethod]
    public void AddItemToList_OneBread_ItemsListWithBreadQuantityOneLinePriceFive()
    {
      string itemType = "bread";
      int quantity = 1;
      decimal expectedLinePrice = 5;
      object[] expectedItemValues = new object[] {quantity, expectedLinePrice};
      bool isItemAdded = _orderObject.AddItemToList(itemType, quantity);
      Assert.IsTrue(isItemAdded);
      Assert.AreEqual(expectedItemValues, _orderObject.ItemsList[itemType]);
    }
  }
}