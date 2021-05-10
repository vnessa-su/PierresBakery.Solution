using System;
using System.Drawing;
using Console = Colorful.Console;
using BakeryMenu.BreadMenu;
using BakeryMenu.PastryMenu;
using UserOrder;

namespace PurchaseOrder
{
  public class Program
  {
    static decimal breadStandardPrice = 5;
    static decimal breadDealPrice = 10;
    static decimal breadNumberOfItemsForDeal = 3;
    private static Bread _breadItem = new Bread(breadStandardPrice, breadDealPrice, breadNumberOfItemsForDeal);

    static decimal pastryStandardPrice = 2;
    static decimal pastryDealPrice = 5;
    static decimal pastryNumberOfItemsForDeal = 3;
    private static Pastry _pastryItem = new Pastry(pastryStandardPrice, pastryDealPrice, pastryNumberOfItemsForDeal);

    private static Order _bakeryOrder = new Order(_breadItem, _pastryItem);

    public static void Main()
    {
      DisplayWelcome();
      DisplayMenu();
      RequestOrderInput();
      DisplayOrder();
      Console.WriteLine("\nThank you for visiting Pierre's Bakery!\n", Color.Blue);
    }

    private static void DisplayWelcome()
    {
      Console.WriteLine("                 ██████");
      Console.WriteLine("     ██      ████████████");
      Console.WriteLine("       ██████████████████");
      Console.WriteLine("       ██████████████████  ▓▓▓▓▓▓▓▓▓▓▓▓");
      Console.WriteLine("     ██████████████████▓▓▓▓▓▓░░░░░░░░▓▓▓▓");
      Console.WriteLine("   ██████████████░░░░░▓▓▓▓▓░░░░░░░░░░░░▓▓▓▓");
      Console.WriteLine("   ████████████░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓");
      Console.WriteLine(" ██████████░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓");
      Console.WriteLine(" ██████▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓");
      Console.WriteLine(" ████  ▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓");
      Console.WriteLine("         ▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓");
      Console.WriteLine("         ▓▓░░████░░░░░░░░░░░░████░░░░██");
      Console.WriteLine("         ▓▓░░████░░░░░░░░░░░░████░░░░██");
      Console.WriteLine("         ▓▓▒▒▒▒░░░░██░░░░██░░░░▒▒▒▒██▓▓");
      Console.WriteLine("         ▓▓░░░░░░░░░░████░░░░░░░░░░██▓▓");
      Console.WriteLine("         ▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓");
      Console.WriteLine("         ▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓");
      Console.WriteLine("         ▓▓░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓");
      Console.WriteLine("         ▓▓▓▓░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓");
      Console.WriteLine("         ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");

      Console.WriteLine("     |-----------------------------------|");
      Console.WriteLine("     |    Welcome to Pierre's Bakery!    |");
      Console.WriteLine("     |-----------------------------------|\n");
    }

    private static void DisplayMenu()
    {
      Console.WriteLine(" Menu \t\t Price");
      Console.WriteLine("------\t\t-------");
      Console.WriteLine("Bread \t\t${0} or Buy {1} get 1 free!", _bakeryOrder.BreadObject.StandardPrice, _bakeryOrder.BreadObject.NumberOfItemsForDeal-1);
      Console.WriteLine("Pastry \t\t${0} or {1} for ${2}", _bakeryOrder.PastryObject.StandardPrice, _bakeryOrder.PastryObject.NumberOfItemsForDeal, _bakeryOrder.PastryObject.DealPrice);
      Console.WriteLine();
    }

    private static void RequestOrderInput()
    {
      string tryAgainInput;
      bool orderComplete = false;

      while(!orderComplete)
      {
        Console.Write("\nWhat would you like to order? ");
        string itemInput = Console.ReadLine().ToLower();

        Console.Write("How many would you like? ");
        string quantityInput = Console.ReadLine();

        try
        {
          int quantity = int.Parse(quantityInput);
          if (quantity < 0)
          {
            throw new Exception("Invalid Quantity - Negative Number");
          }

          if (itemInput == "bread")
          {
            int totalBreadQuantity = quantity;
            if(_bakeryOrder.ItemsList.ContainsKey("bread"))
            {
              totalBreadQuantity += (int)_bakeryOrder.ItemsList["bread"][0];
            }
            int extraItemCount = OfferFreeBreadItemIfQualifies(totalBreadQuantity);
            quantity += extraItemCount;
          }

          bool isItemAdded = _bakeryOrder.AddItemToList(itemInput, quantity);
          if(isItemAdded)
          {
            Console.WriteLine("Added {0} x{1}\n", itemInput.ToUpper(), quantity, Color.Green);
          }
          else
          {
            Console.WriteLine("Nothing Added - Invalid Item or Zero Quantity\n", Color.Red);
          }
        }
        catch
        {
          Console.WriteLine("Nothing Added - Invalid Quantity: {0}\n", quantityInput, Color.Red);
        }

        Console.Write("Would you like to add another item? [N to complete order] ");
        tryAgainInput = Console.ReadLine().ToLower();
        if (tryAgainInput.Length != 0)
        {
          if (tryAgainInput[0] == 'n')
          {
            orderComplete = true;
          }
        }
      }
    }

    private static int OfferFreeBreadItemIfQualifies(int quantityOfItem)
    {
      bool orderQualified = _breadItem.CanGetFreeItem(quantityOfItem);
      string wantFreeItemAdded;
      if (orderQualified)
      {
        Console.WriteLine("\nYour order qualifies for a free item!");
        Console.Write("Would you like to add this item to your order? [Y to add] ");
        wantFreeItemAdded = Console.ReadLine().ToLower();

        if(wantFreeItemAdded.Length != 0)
        {
          if(wantFreeItemAdded[0] == 'y')
          {
            return 1;
          }
        }
      }
        return 0;
    }

    private static void DisplayOrder()
    {
      Console.WriteLine("---------------------------------", Color.DarkCyan);
      Console.WriteLine("              Order", Color.DarkCyan);
      Console.WriteLine("---------------------------------\n", Color.DarkCyan);

      foreach (string key in _bakeryOrder.ItemsList.Keys)
      {
        string item = key.ToUpper();
        int quantity = (int)_bakeryOrder.ItemsList[key][0];
        decimal linePrice = (decimal)_bakeryOrder.ItemsList[key][1];
        Console.WriteLine("{0} x{1} \t\t{2:C}\n", item, quantity, linePrice, Color.DarkCyan);
      }

      decimal orderCost = _bakeryOrder.GetTotalCost();
      Console.WriteLine("---------------------------------", Color.DarkCyan);
      Console.WriteLine("\tOrder Total: \t{0:C}", orderCost, Color.DarkCyan);
    }
  }
}