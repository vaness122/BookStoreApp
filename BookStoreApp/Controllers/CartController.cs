using BookStoreApp;
using BookStoreApp.Data;
using BookStoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using BookStoreApp.Helpers;

public class CartController : Controller
{
    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }

    //Display Cart
    public IActionResult Index()
    {
        var cartItems = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "Cart") ?? new List<Cart>();
  
       
        return View(cartItems);
    }

    //Add Item to Cart
    public IActionResult AddToCart(int bookId)
    {
        var book = _context.Books.Find(bookId);
        if (book != null)
        {
            var cartItems = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "Cart") ?? new List<Cart>();

            var cartItem = cartItems.FirstOrDefault(c => c.Book.BookId == bookId);
            if (cartItem == null)
            {
                cartItems.Add(new Cart { Book = book, Quantity = 1 });
            }
            else
            {
                cartItem.Quantity++;
            }

           
            SessionHelper.SetObjectAsJson(HttpContext.Session, "Cart", cartItems);
        }
        return RedirectToAction("Index");
    }


    public IActionResult RemoveFromCart(int bookId)
    {
        var cartItems = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session,"Cart") ?? new List<Cart>();

        
        var cartItem = cartItems.FirstOrDefault(c => c.Book.BookId == bookId);

        //Remove from the cart
        if (cartItem != null)
        {
            cartItems.Remove(cartItem);
        }

        // Save the updated cart back to the session
        SessionHelper.SetObjectAsJson(HttpContext.Session, "Cart", cartItems);

        // Redirect to the cart index
        return RedirectToAction("Index");
    }
}
    





