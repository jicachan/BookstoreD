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
      ViewBag.SyncOrAsync = "Synchronous";
      return View();
    }

    public ActionResult Cart()
    {
      ViewBag.Message = "Your Shopping Cart.";
      return View();
    }


    public async Task<ActionResult> BooksAsync()
    {      
      var bookstoreService = new BookstoreService();
      ViewBag.Books = await bookstoreService.GetBooksAsync(Request.Form["searchString"]);
      return View("Index");
    }

  }
}