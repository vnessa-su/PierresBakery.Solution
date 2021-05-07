using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PastryMenu.Tests
{
  [TestClass]
  public class PastryMenuTests
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
  }
}