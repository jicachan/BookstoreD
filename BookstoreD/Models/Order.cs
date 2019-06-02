using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreD
{
  public class Order
  {
    // Instance variables
    List<Book> orderList = new List<Book>();
    List<Book> backorderList = new List<Book>();    

    // Properties
    public List<Book> OrderList => orderList;
    public List<Book> OutOfStockList => backorderList;


    // Method: Make an order and show confirmation - Otestad
    public void CreateOrder(ShoppingCart cart)
    {
      AddItemsToOrderList(cart.Shopcart);
      GetTotalSumOfOrder(orderList);
    }

    // Method: Add items from cartList to orderList
    public void AddItemsToOrderList(List<Book> cart)
    {
      // Empty lists
      orderList.Clear();
      backorderList.Clear();

      if (cart != null && cart.Any())
      {
        foreach (var book in cart)
        {
          if (book.InStock > 0)
          {
            orderList.Add(book);
          }
          else
          {
            backorderList.Add(book);
          }
        }
      }
    }


    // Method: Show total sum of order
    public decimal GetTotalSumOfOrder(List<Book> list)
    {
      // Reset totalSum
      decimal totalSumOfOrder = 0;

      if (list != null && list.Any())
      {
        foreach (var b in list)
        {
          totalSumOfOrder += b.Price;
        }
      }
      return totalSumOfOrder;
    }

  }
}