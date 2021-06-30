using BookManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        //ListBook
        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.Books.ToList();
            return View(listBook);
        }

        //Buy
        [Authorize]
        public ActionResult Buy(int id=1)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //CreateBook
        [Authorize]
        public ActionResult createBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "TenSach,GiaBan,GiaBia,AnhBia")] Book book)
        {
            BookManagerContext context = new BookManagerContext();
            var list = context.Books.ToList();
            context.Books.Add(book);
            context.SaveChanges();
            return RedirectToAction("listBook", list);
        }

        //EditBook
        [Authorize]
        public ActionResult editBook(int id = 1)
        {
            BookManagerContext context = new BookManagerContext();
            var book = context.Books.ToList();
            Book b = new Book();
            foreach (Book i in book)
            {
                if (i.ID == id)
                {
                    b = i;
                    break;
                }

            }
            if (b == null)
                return HttpNotFound();
            return View(b);
        }

        //post: Book/EditBook/Id
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string title, int prices, string author, string descryption, string images)
        {
            BookManagerContext context = new BookManagerContext();
            var list = context.Books.ToList();
            Book book = list.FirstOrDefault(p => p.ID == id);
            if (book != null)
            {
                book.Title = title;
                book.Prices = prices;
                book.Author = author;
                book.Description = descryption;
                book.Images = images;
                context.Books.AddOrUpdate(book);
                context.SaveChanges();
            }

            return RedirectToAction("listBook", list);
        }

        //DeleteBook
        public ActionResult deleteBook(int id = 1)
        {
            BookManagerContext context = new BookManagerContext();
            var list = context.Books.ToList();
            Book b = new Book();
            foreach (Book i in list)
            {
                if (i.ID == id)
                {
                    b = i;
                    break;
                }
            }
            if (b == null)
                return HttpNotFound();
            return View(b);
        }

        [HttpPost, ActionName("deleteBook")]
        [ValidateAntiForgeryToken]
        public ActionResult deleteBookConfirm(int id)
        {

            BookManagerContext context = new BookManagerContext();
            var list = context.Books.ToList();
            Book book = list.FirstOrDefault(p => p.ID == id);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }

            return RedirectToAction("listBook", list);
        }

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize]
        //public ActionResult CreateBook(int id)
        //{
        //    BookManagerContext context = new BookManagerContext();
        //    Book book = context.Books.SingleOrDefault(p => p.ID == id);
        //    context.Books.AddOrUpdate(book); //Add or Update Book b
        //    context.SaveChanges();
        //    return View(book);
        //}

        //[Authorize]
        //public ActionResult EditBook(int id)
        //{
        //    BookManagerContext context = new BookManagerContext();
        //    Book book = context.Books.SingleOrDefault(p => p.ID == id);
        //    Book dbUpdate = context.Books.FirstOrDefault(p => p.ID == id);
        //    if (dbUpdate != null)
        //    {
        //        context.Books.AddOrUpdate(book); //Add or Update Book b
        //        context.SaveChanges();
        //    }
        //    return View(book);
        //}

        //[Authorize]
        //public ActionResult DeleteBook(int id)
        //{
        //    BookManagerContext context = new BookManagerContext();
        //    Book db = context.Books.FirstOrDefault(p => p.ID == id);
        //    Book dbDelete = context.Books.FirstOrDefault(p => p.ID == id);
        //    if (dbDelete != null)
        //    {
        //        context.Books.Remove(db);
        //        context.SaveChanges();
        //    }
        //    return View(book);
        //}



    }
}