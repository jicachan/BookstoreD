﻿using System;
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
    decimal orderTotalSum; 

    // Properties
    public List<Book> OrderList { get => orderList; set => orderList = value; }
    public List<Book> BackorderList { get => backorderList; set => backorderList = value; }
    public decimal OrderTotalSum { get => orderTotalSum; set => orderTotalSum = value; }


    // Method: Add items from cartList to orderList
    public void AddItemsToOrderList(List<Book> cart)
    {
      // Empty lists
      OrderList.Clear();
      BackorderList.Clear();

      if (cart != null && cart.Any())
      {
        foreach (var book in cart)
        {
          if (book.InStock > 0)
          {
            OrderList.Add(book);
          }
          else
          {
            BackorderList.Add(book);
          }
        }
      }
    }


    // Method: Show total sum of order
    public decimal GetTotalSumOfOrder(List<Book> list)
    {
      // Reset totalSum
      orderTotalSum = 0;
      if (list != null && list.Any())
      {
        foreach (var b in list)
        {
          orderTotalSum += b.Price;
        }
      }
      return orderTotalSum;
    }

  }
}