using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BakeryMenu.BreadMenu.Tests
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

    [TestMethod]
    public void CanGetFreeItem_Zero_False()
    {
      int inputNumberOfItems = 0;
      bool expectedAnswer = false;
      bool returnedAnswer = _breadObject.CanGetFreeItem(inputNumberOfItems);
      Assert.AreEqual(expectedAnswer, returnedAnswer);
    }

    [TestMethod]
    public void CanGetFreeItem_Two_True()
    {
      int inputNumberOfItems = 2;
      bool expectedAnswer = true;
      bool returnedAnswer = _breadObject.CanGetFreeItem(inputNumberOfItems);
      Assert.AreEqual(expectedAnswer, returnedAnswer);
    }

    [TestMethod]
    public void CanGetFreeItem_Seven_False()
    {
      int inputNumberOfItems = 7;
      bool expectedAnswer = false;
      bool returnedAnswer = _breadObject.CanGetFreeItem(inputNumberOfItems);
      Assert.AreEqual(expectedAnswer, returnedAnswer);
    }

    [TestMethod]
    public void CanGetFreeItem_Eleven_True()
    {
      int inputNumberOfItems = 11;
      bool expectedAnswer = true;
      bool returnedAnswer = _breadObject.CanGetFreeItem(inputNumberOfItems);
      Assert.AreEqual(expectedAnswer, returnedAnswer);
    }
  }
}