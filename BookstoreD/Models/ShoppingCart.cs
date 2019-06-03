using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreD
{
  public class ShoppingCart 
  {
    // Variables
    List<Book> shopcart = new List<Book>();
    decimal totalSum = 0;

    // Properties
    public List<Book> Shopcart { get => shopcart; set => shopcart = value; }
    public decimal TotalSum { get => totalSum; set => totalSum = value; }

    

    // Method: Add a book to cart, without checking instock 
    public List<Book> AddBookToCart(Book book)
    {      
      shopcart.Add(book);
      return shopcart;
    }

   


    // Method: Remove a book from cart
    public void RemoveBookFromCartByTitle (string removeItem)
    {
      foreach (var b in shopcart)
      {
        if (b.Title == removeItem)
        {
          shopcart.Remove(b);         
          break;
        }        
      }      
    }


    // Method: Show total sum of order
    public decimal GetTotalSum(List<Book> list)
    {      
      TotalSum = 0; // Reset totalsum
      if (list != null && list.Any())
      {
        foreach (var b in list)
        {
          TotalSum += b.Price;
        }
      }      
      return TotalSum;
    }
  }
}
