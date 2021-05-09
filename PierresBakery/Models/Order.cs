using System.Collections.Generic;
using BreadMenu;
using PastryMenu;

namespace UserOrder
{
  public class Order
  {
    public Dictionary<string, object[]> ItemsList {get; private set;}
    private Bread _breadObject;
    private Pastry _pastryObject;

    public Order()
    {
      ItemsList = new Dictionary<string, object[]>();
      _breadObject = new Bread(5, 10, 3);
      _pastryObject = new Pastry(2, 5, 3);
    }

    public bool AddItemToList(string itemType, int quantity)
    {
      decimal lineItemPrice;
      string typeOfItem;

      if (quantity <= 0)
      {
        return false;
      }
      
      if(itemType.ToLower() == "bread")
      {
        lineItemPrice = _breadObject.GetCost(quantity);
        typeOfItem = "bread";
      }
      else if(itemType.ToLower() == "pastry" || itemType.ToLower() == "pastries")
      {
        lineItemPrice = _pastryObject.GetCost(quantity);
        typeOfItem = "pastry";
      }
      else
      {
        return false;
      }

      ItemsList.Add(typeOfItem, new object[]{quantity, lineItemPrice});
      return true;
    }
  }
}