using Microsoft.VisualStudio.TestTools.UnitTesting;
using BreadMenu;

namespace BreadMenu.Tests
{
  [TestClass]
  public class BreadMenuTests
  {
    private Bread _breadObject = new Bread();

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