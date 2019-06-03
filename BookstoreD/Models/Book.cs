using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreD
{
  public class Book : IBook
  {
    // Instance variables
    string title;
    string author;
    decimal price;
    int inStock;

    // Properties
    public string Title
    {
      get { return title; }
      set { title = value; }
    }

    // Constructor
    public Book() { }

    public Book(string title, string author, decimal price, int inStock)
    {
      Title = title;
      Author = author;
      Price = price;
      InStock = inStock;
    }

    public string Author
    {
      get { return author; }
      set { author = value; }
    }
    public decimal Price
    {
      get { return price; }
      set
      {
        if (value < 0) // Negative not allowed
        {
          return;
        }
        price = value;
      }
    }

    public int InStock
    {
      get { return inStock; }
      set
      {
        if (value < 0)
        {
          return;
        }
        inStock = value;
      }
    }
  }
}
