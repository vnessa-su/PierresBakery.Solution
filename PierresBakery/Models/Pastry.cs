namespace PastryMenu
{
  public class Pastry
  {
    private decimal StandardPrice {get; set;}
    private decimal DealPrice {get; set;}
    private decimal NumberOfItemsForDeal {get; set;}

    public Pastry(decimal standardItemPrice, decimal dealPrice, decimal numberOfItemsForDeal)
    {
      StandardPrice = standardItemPrice;
      DealPrice = dealPrice;
      NumberOfItemsForDeal = numberOfItemsForDeal;
    }

    public decimal GetCost(int numberOfItems)
    {
      decimal cost = 0;
      return cost;
    }
  }
}