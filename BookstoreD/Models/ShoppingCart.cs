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
    private List<Book> shopcart;

    // Properties
    public List<Book> Shopcart { get => shopcart; set => shopcart = value; }  



    // Method: Add a book to cart, without checking instock 
    public void AddBookToCart(Book book)
    {      
      shopcart.Add(book);     
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
