using System.Collections.Generic;
using BakeryMenu;
using BakeryMenu.BreadMenu;
using BakeryMenu.PastryMenu;

namespace UserOrder
{
  public class Order
  {
    public Dictionary<string, object[]> ItemsList {get; private set;}
    public Bread BreadObject {get; private set;}
    public Pastry PastryObject {get; private set;}

    public Order(Bread breadObject, Pastry pastryObject)
    {
      ItemsList = new Dictionary<string, object[]>();
      BreadObject = breadObject;
      PastryObject = pastryObject;
    }

    public bool AddItemToList(string itemType, int quantity)
    {
      decimal lineItemPrice;
      string typeOfItem = itemType.ToLower();
      BakeryItem category;

      if (quantity <= 0)
      {
        return false;
      }

      if(ItemsList.ContainsKey(typeOfItem))
      {
        int currentQuantity = (int)ItemsList[typeOfItem][0];
        int updatedQuantity = currentQuantity + quantity;

        category = (BakeryItem)ItemsList[typeOfItem][2];
        lineItemPrice = category.GetCost(updatedQuantity);
        
        ItemsList[typeOfItem][0] = updatedQuantity;
        ItemsList[typeOfItem][1] = lineItemPrice;
        return true;
      }

      if(typeOfItem == "bread")
      {
        lineItemPrice = BreadObject.GetCost(quantity);
        category = BreadObject;
      }
      else if(typeOfItem == "pastry" || typeOfItem == "pastries")
      {
        typeOfItem = "pastry";
        lineItemPrice = PastryObject.GetCost(quantity);
        category = PastryObject;
      }
      else
      {
        return false;
      }

      ItemsList.Add(typeOfItem, new object[]{quantity, lineItemPrice, category});
      return true;
    }

    public decimal GetTotalCost()
    {
      decimal totalCost = 0;
      if (ItemsList.Count == 0)
      {
        return totalCost;
      }

      foreach(object[] value in ItemsList.Values)
      {
        totalCost += (decimal)value[1];
      }
      return totalCost;
    }
  }
}