using System;

namespace BreadMenu
{
  public class Bread
  {
    public decimal StandardPrice {get; private set;}
    public decimal DealPrice {get; private set;}
    public decimal NumberOfItemsForDeal {get; private set;}

    public Bread(decimal standardItemPrice, decimal dealPrice, decimal numberOfItemsForDeal)
    {
      StandardPrice = standardItemPrice;
      DealPrice = dealPrice;
      NumberOfItemsForDeal = numberOfItemsForDeal;
    }

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