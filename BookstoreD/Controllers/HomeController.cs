using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookstoreD.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Cart()
    {      
      return View();
    }

    public ActionResult Order()
    {
      ViewBag.Title = "Din orderbekräftelse";
      return View();
    }
    
    public ActionResult AddToCart()
    {
      ShoppingCart scart = new ShoppingCart();
      Book book = new Book(Request.Form["title"], Request.Form["author"], Convert.ToDecimal(Request.Form["price"]), Convert.ToInt32(Request.Form["instock"]));

      ViewBag.AddedBookList = scart.AddBookToCart(book);
      //Session["InCart"] = sc.Shopcart;
            
      // Make book info into json-format
      string session = JsonConvert.SerializeObject(scart.Shopcart);
      System.Web.HttpContext.Current.Session["booksAddedToCart"] = session;
            
      ViewBag.Confirm = book.Title + " has been added to shopping cart.";      
      return View("Index");
    }

    public async Task<ActionResult> BooksAsync()
    {      
      var bookstoreService = new BookstoreService();
      ViewBag.Books = await bookstoreService.GetBooksAsync(Request.Form["searchString"]);
      return View("Index");
    }
  }
}