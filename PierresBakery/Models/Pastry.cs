using System;

namespace BakeryMenu.PastryMenu
{
  public class Pastry : BakeryItem
  {
    public Pastry(decimal standardItemPrice, decimal dealPrice, decimal numberOfItemsForDeal)
    {
      StandardPrice = standardItemPrice;
      DealPrice = dealPrice;
      NumberOfItemsForDeal = numberOfItemsForDeal;
    }
  }
}