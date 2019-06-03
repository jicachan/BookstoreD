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
      ViewBag.Message = "Kundvagnen";
      return View();
    }

    public ActionResult Order()
    {
      ViewBag.Title = "Din orderbekräftelse";
      return View();
    }

    public ActionResult AddToCart()
    {
      ShoppingCart sc = new ShoppingCart();

      string chosenBook = Request.Form["selectedBookTitle"];
      ViewBag.BookTitle = chosenBook;
      return View("Cart");
    }

    public async Task<ActionResult> BooksAsync()
    {      
      var bookstoreService = new BookstoreService();
      ViewBag.Books = await bookstoreService.GetBooksAsync(Request.Form["searchString"]);
      return View("Index");
    }


  }
}