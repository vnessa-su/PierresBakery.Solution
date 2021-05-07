using System;

namespace BreadMenu
{
  public class Bread
  {
    public decimal GetCost(int numberOfItems)
    {
      decimal cost = 0;
      decimal setsOfThree = Math.Floor((decimal)numberOfItems / 3);
      decimal remainingItems = numberOfItems % 3;
      cost = (setsOfThree * 10) + (remainingItems * 5);
      return cost;
    }
  }
}