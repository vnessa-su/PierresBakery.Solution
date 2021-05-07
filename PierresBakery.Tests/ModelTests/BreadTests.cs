using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BreadMenu.Tests
{
  [TestClass]
  public class BreadTests
  {
    static decimal standardItemPrice = 5;
    static decimal dealPrice = 10;
    static decimal numberOfItemsForDeal = 3;
    private Bread _breadObject = new Bread(standardItemPrice, dealPrice, numberOfItemsForDeal);

    [TestMethod]
    public void GetCost_Zero_Zero()
    {
      int inputNumberOfItems = 0;
      decimal expectedCost = 0;
      decimal returnedCost = _breadObject.GetCost(inputNumberOfItems);
      Assert.AreEqual(expectedCost, returnedCost);
    }

    [TestMethod]
    public void GetCost_One_Five()
    {
      int inputNumberOfItems = 1;
      decimal expectedCost = 5;
      decimal returnedCost = _breadObject.GetCost(inputNumberOfItems);
      Assert.AreEqual(expectedCost, returnedCost);
    }

    [TestMethod]
    public void GetCost_Three_Ten()
    {
      int inputNumberOfItems = 3;
      decimal expectedCost = 10;
      decimal returnedCost = _breadObject.GetCost(inputNumberOfItems);
      Assert.AreEqual(expectedCost, returnedCost);
    }

    [TestMethod]
    public void GetCost_Seven_TwentyFive()
    {
      int inputNumberOfItems = 7;
      decimal expectedCost = 25;
      decimal returnedCost = _breadObject.GetCost(inputNumberOfItems);
      Assert.AreEqual(expectedCost, returnedCost);
    }
  }
}