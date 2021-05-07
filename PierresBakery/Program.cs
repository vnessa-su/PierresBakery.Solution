using System;
using BreadMenu;
using PastryMenu;

namespace PurchaseOrder
{
  public class Program
  {
    public static void Main()
    {
      decimal breadStandardPrice = 5;
      decimal breadDealPrice = 10;
      decimal breadNumberOfItemsForDeal = 3;
      Bread breadItem = new Bread(breadStandardPrice, breadDealPrice, breadNumberOfItemsForDeal);

      decimal pastryStandardPrice = 5;
      decimal pastryDealPrice = 10;
      decimal pastryNumberOfItemsForDeal = 3;
      Pastry pastryItem = new Pastry(pastryStandardPrice, pastryDealPrice, pastryNumberOfItemsForDeal);

      Console.WriteLine("|-----------------------------|");
      Console.WriteLine("| Welcome to Pierre's Bakery! |");
      Console.WriteLine("|-----------------------------|\n");
      Console.WriteLine(" Menu");
      Console.WriteLine("------");
      Console.WriteLine("Bread \t\t${0} or Buy 2 get 1 free!", breadStandardPrice);
      Console.WriteLine("Pastry \t\t${0} or 3 for ${1}", pastryStandardPrice, pastryDealPrice);
    }
  }
}