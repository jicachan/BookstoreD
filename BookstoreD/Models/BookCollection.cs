using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreD
{
  public class BookCollection
  {
    // Collection of books, storing json_data
    private IEnumerable<Book> books;
    public IEnumerable<Book> Books
    {
      get => books;
      set => books = value;
    }

  }
}