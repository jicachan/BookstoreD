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

    // Get books from bookstore and search string
    public async Task<ActionResult> BooksAsync()
    {
      var bookstoreService = new BookstoreService();
      ViewBag.Books = await bookstoreService.GetBooksAsync(Request.Form["searchString"]);
      return View("Index");
    }

    public ActionResult Cart()
    {
      ShoppingCart cart = new ShoppingCart();

      if(System.Web.HttpContext.Current.Session["booksAddedToCart"] == null)
      {
        ViewBag.Message = "Din kundvagn är tom.";
      }
      else
      {        
        ViewBag.Message = "Din kundvagn innehåller ";
        ViewBag.BooksInCart = cart.GetCartItemsFromJsonString(System.Web.HttpContext.Current.Session["booksAddedToCart"].ToString());
        ViewBag.TotalSum = cart.GetTotalSum(cart.Shopcart);
      }
      return View();
    }

    // Add Book book to shopcart and to cartJSON
    public ActionResult AddToCart()
    {
      ShoppingCart tempCart = new ShoppingCart();
      Book book = new Book(Request.Form["title"], Request.Form["author"], Convert.ToDecimal(Request.Form["price"]), Convert.ToInt32(Request.Form["instock"]));

      // Add book to cart
      ViewBag.AddedBookList = tempCart.AddBookToCart(book);

      if (System.Web.HttpContext.Current.Session["booksAddedToCart"] == null)
      {
        // Empty. Store item data into json-string        
        System.Web.HttpContext.Current.Session["booksAddedToCart"] = tempCart.StoreCartItemsToJsonSession(tempCart.Shopcart);
      }
      else
      {
        // Not empty. Copy content to shopcart, then add to cart, then store data back into json-string
        tempCart.Shopcart = tempCart.GetCartItemsFromJsonString(System.Web.HttpContext.Current.Session["booksAddedToCart"].ToString());

        // Add book to cart
        tempCart.AddBookToCart(book);

        // Store data back into json-string to session        
        System.Web.HttpContext.Current.Session["booksAddedToCart"] = tempCart.StoreCartItemsToJsonSession(tempCart.Shopcart);
      }

      // Send data to View
      ViewBag.Confirm = book.Title + " har lagts till i kundvagnen.";
      return View("Index");
    }

    public ActionResult RemoveFromCart()
    {
      ShoppingCart tempCart = new ShoppingCart();

      // Get jsondata
      tempCart.Shopcart = tempCart.GetCartItemsFromJsonString(System.Web.HttpContext.Current.Session["booksAddedToCart"].ToString());

      // Remove book from shopcart by title
      tempCart.RemoveBookFromCartByTitle(Request.Form["title"]);

      // Store data back into json-string
      System.Web.HttpContext.Current.Session["booksAddedToCart"] = tempCart.StoreCartItemsToJsonSession(tempCart.Shopcart);

      // Send data to View
      ViewBag.Message = "Din kundvagn innehåller ";
      ViewBag.BooksInCart = tempCart.GetCartItemsFromJsonString(System.Web.HttpContext.Current.Session["booksAddedToCart"].ToString());
      ViewBag.TotalSum = tempCart.GetTotalSum(tempCart.Shopcart);
      return View("Cart");
    }

    public ActionResult Order()
    {
      ShoppingCart cart = new ShoppingCart();
      Order order = new Order();

      if (System.Web.HttpContext.Current.Session["booksAddedToCart"] == null)
      {
        ViewBag.Title = "Du har ingen beställning än.";        
      }

      if (System.Web.HttpContext.Current.Session["booksInOrder"] != null)
      {        
        ViewBag.Title = "Din orderbekräftelse";
        ViewBag.OrderMessage = "Böcker i din beställning";
        ViewBag.Orderlist = order.OrderList;
        ViewBag.BackorderMessage = "Följande produkt(er) är slut i lagret.";
        ViewBag.Backorderlist = order.BackorderList;        
        ViewBag.Title = "Tack för din beställning!";
        ViewBag.TotalSum = order.GetTotalSumOfOrder(order.OrderList);
      }
      return View();
    }

    public ActionResult MakeAnOrder()
    {
      ShoppingCart cart = new ShoppingCart();
      Order order = new Order();

      if (System.Web.HttpContext.Current.Session["booksAddedToCart"] == null)
      {
        ViewBag.Title = "Du har ingen beställning än.";

      }
      // Get cart items from session json-data
      cart.Shopcart = cart.GetCartItemsFromJsonString(System.Web.HttpContext.Current.Session["booksAddedToCart"].ToString());

      // Check if item is in stock, then add to orderlist and store in json
      order.AddItemsToOrderList(cart.Shopcart);
      string session = JsonConvert.SerializeObject(cart.Shopcart);
      System.Web.HttpContext.Current.Session["booksInOrder"] = session;      

      // Send data to View
      ViewBag.OrderMessage = "Böcker i din beställning";
      ViewBag.Orderlist = order.OrderList;
      ViewBag.BackorderMessage = "Följande produkt(er) är slut i lagret.";
      ViewBag.Backorderlist = order.BackorderList;      
      ViewBag.Title = "Tack för din beställning!";
      ViewBag.TotalSum = order.GetTotalSumOfOrder(order.OrderList);
      return View("Order");
    }
  }
}