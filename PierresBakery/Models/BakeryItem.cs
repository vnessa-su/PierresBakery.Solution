using System;

namespace BakeryMenu
{
  public class BakeryItem
  {
    public decimal StandardPrice {get; set;}
    public decimal DealPrice {get; set;}
    public decimal NumberOfItemsForDeal {get; set;}

    public decimal GetCost(int numberOfItems)
    {
      decimal cost = 0;
      decimal setsOfDealNumberItems = Math.Floor((decimal)numberOfItems / NumberOfItemsForDeal);
      decimal remainingItems = numberOfItems % NumberOfItemsForDeal;
      cost = (setsOfDealNumberItems * DealPrice) + (remainingItems * StandardPrice);
      return cost;
    }
  }
}