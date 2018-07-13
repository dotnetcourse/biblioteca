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
        private static List<BookModel> bookList = new List<BookModel>();

        // GET: Books
        public ActionResult List()
        {
            return View(bookList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BookModel book)
        {
            bookList.Add(book);

            return View("AddSuccess");
        }
    }
}