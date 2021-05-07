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
      Console.WriteLine(" Menu \t\t Price");
      Console.WriteLine("------\t\t-------");
      Console.WriteLine("Bread \t\t${0} or Buy {1} get 1 free!", _breadItem.StandardPrice, _breadItem.NumberOfItemsForDeal-1);
      Console.WriteLine("Pastry \t\t${0} or {1} for ${2}", _pastryItem.StandardPrice, _pastryItem.NumberOfItemsForDeal, _pastryItem.DealPrice);
      Console.WriteLine();
      decimal orderCost = RequestOrderInput();
      Console.WriteLine("Order Total: {0:C}", orderCost);
    }

    private static decimal RequestOrderInput()
    {
      decimal orderCost = 0;
      string tryAgainInput;
      bool orderComplete = false;

      while(!orderComplete)
      {
        Console.Write("What would you like to order? ");
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
            orderCost += _breadItem.GetCost(quantity);
          }
          else if (itemInput == "pastry" || itemInput == "pastries")
          {
            orderCost += _pastryItem.GetCost(quantity);
          }
          else
          {
            Console.WriteLine("Unknown Item - Nothing Added", Color.Red);
          }
        }
        catch
        {
          Console.WriteLine("Invalid Quantity - Nothing Added", Color.Red);
        }

        Console.Write("Would you like to add another item? [y/n] ");
        tryAgainInput = Console.ReadLine().ToLower();
        if (tryAgainInput[0] == 'n')
        {
          orderComplete = true;
        }
      }
      
      return orderCost;
    }
  }
}