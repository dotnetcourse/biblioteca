using Biblioteca1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca1.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult List()
        {
            Repository rep = new Repository();
            List<BookModel> books = rep.GetBooks();

            return View(books);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BookModel book)
        {
            Repository rep = new Repository();
            rep.AddBook(book);

            return View("AddSuccess");
        }

        public ActionResult Delete()
        {
            Repository rep = new Repository();
            rep.DeleteBook(1);

            return View();
        }
    }
}