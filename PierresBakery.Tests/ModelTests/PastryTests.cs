using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PastryMenu.Tests
{
  [TestClass]
  public class PastryTests
  {
    static decimal standardItemPrice = 2;
    static decimal dealPrice = 5;
    static decimal numberOfItemsForDeal = 3;
    private Pastry _pastryObject = new Pastry(standardItemPrice, dealPrice, numberOfItemsForDeal);

    [TestMethod]
    public void GetCost_Zero_Zero()
    {
      int inputNumberOfItems = 0;
      decimal expectedCost = 0;
      decimal returnedCost = _pastryObject.GetCost(inputNumberOfItems);
      Assert.AreEqual(expectedCost, returnedCost);
    }

    [TestMethod]
    public void GetCost_One_Two()
    {
      int inputNumberOfItems = 1;
      decimal expectedCost = 2;
      decimal returnedCost = _pastryObject.GetCost(inputNumberOfItems);
      Assert.AreEqual(expectedCost, returnedCost);
    }
  }
}