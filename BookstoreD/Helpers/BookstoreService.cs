
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreD
{
  class BookstoreService : IBookstoreService
  {
    // Method: Filter books by search string
    public IEnumerable<IBook> GetBookByTitleOrAuthor(string searchString, BookCollection bookstore)
    {
      IEnumerable<IBook> searchResults = null;          
      if (!String.IsNullOrEmpty(searchString))
      {
        searchResults = bookstore.Books.Where(s => (s.Title.ToLower().Contains(searchString.ToLower())) || (s.Author.ToLower().Contains(searchString.ToLower()))).ToList();
      }
      return searchResults;
    }

    // Method: Get booklist from json (url) and Search for book by title or author, return list of Book
    public async Task<IEnumerable<IBook>> GetBooksAsync(string searchString)
    {
      var uri = "https://raw.githubusercontent.com/contribe/contribe/dev/arbetsprov-net/books.json";
      using (HttpClient httpClient = new HttpClient())
      {
        var response = await httpClient.GetAsync(uri);
        var jsonData = await response.Content.ReadAsStringAsync();
        
        BookCollection books = null;
        
        if (!string.IsNullOrEmpty(jsonData))
        {
          // Convert jsondata to a serie of objects
          books = JsonConvert.DeserializeObject<BookCollection>(jsonData);
        }
        IEnumerable<IBook> searchResults = null;        
        if (!String.IsNullOrWhiteSpace(searchString))
        {
          searchResults = GetBookByTitleOrAuthor(searchString, books);
        }
        string session = JsonConvert.SerializeObject(searchResults);
        System.Web.HttpContext.Current.Session["searchResultsInSession"] = session;
        return searchResults;
      }

    }



  }
}
