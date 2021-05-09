using System;

namespace BakeryMenu.BreadMenu
{
  public class Bread : BakeryItem
  {
    public Bread(decimal standardItemPrice, decimal dealPrice, decimal numberOfItemsForDeal)
    {
      StandardPrice = standardItemPrice;
      DealPrice = dealPrice;
      NumberOfItemsForDeal = numberOfItemsForDeal;
    }

    public bool CanGetFreeItem(int numberOfItems)
    {
      decimal remainingItems = numberOfItems % NumberOfItemsForDeal;
      if (remainingItems == NumberOfItemsForDeal-1)
      {
        return true;
      }
      return false;
    }
  }
}