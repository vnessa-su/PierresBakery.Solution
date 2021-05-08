using System;
using System.Drawing;
using Console = Colorful.Console;
using BreadMenu;
using PastryMenu;

namespace PurchaseOrder
{
  public class Program
  {
    static decimal breadStandardPrice = 5;
    static decimal breadDealPrice = 10;
    static decimal breadNumberOfItemsForDeal = 3;
    private static Bread _breadItem = new Bread(breadStandardPrice, breadDealPrice, breadNumberOfItemsForDeal);

    static decimal pastryStandardPrice = 2;
    static decimal pastryDealPrice = 10;
    static decimal pastryNumberOfItemsForDeal = 3;
    private static Pastry _pastryItem = new Pastry(pastryStandardPrice, pastryDealPrice, pastryNumberOfItemsForDeal);

    public static void Main()
    {
      DisplayWelcome();
      DisplayMenu();
      decimal orderCost = RequestOrderInput();
      Console.WriteLine("\nOrder Total: {0:C}", orderCost, Color.DarkCyan);
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
      Console.WriteLine("Bread \t\t${0} or Buy {1} get 1 free!", _breadItem.StandardPrice, _breadItem.NumberOfItemsForDeal-1);
      Console.WriteLine("Pastry \t\t${0} or {1} for ${2}", _pastryItem.StandardPrice, _pastryItem.NumberOfItemsForDeal, _pastryItem.DealPrice);
      Console.WriteLine();
    }

    private static decimal RequestOrderInput()
    {
      decimal orderCost = 0;
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

          decimal itemCost;
          switch(itemInput)
          {
            case "bread":
              int extraItemCount = OfferFreeBreadItemIfQualifies(quantity);
              int totalQuantity = quantity + extraItemCount;
              itemCost = _breadItem.GetCost(totalQuantity);
              orderCost += itemCost;
              Console.WriteLine("Added {0} x{1} for {2:C}\n", itemInput.ToUpper(), totalQuantity, itemCost, Color.Green);
              break;
            case "pastry":
            case "pastries":
              itemCost = _pastryItem.GetCost(quantity);
              orderCost += itemCost;
              Console.WriteLine("Added {0} x{1} for {2:C}\n", itemInput.ToUpper(), quantity, itemCost, Color.Green);
              break;
            default:
              Console.WriteLine("Nothing Added - Unknown Item: {0}\n", itemInput, Color.Red);
              break;
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
      return orderCost;
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
  }
}