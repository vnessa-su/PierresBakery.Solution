namespace BreadMenu
{
  public class Bread
  {
    public decimal GetCost(int numberOfItems)
    {
      decimal cost = 0;
      cost = numberOfItems * 5;
      return cost;
    }
  }
}