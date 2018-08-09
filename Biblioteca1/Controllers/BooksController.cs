using Biblioteca1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            BooksRepository r = new BooksRepository();

            List<BookModel> myBooks = r.GetAll();

            return View(myBooks);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BookModel book)
        {
            //bookList.Add(book);
            BooksRepository r = new BooksRepository();

            r.Add(book);

            return View("AddSuccess");
        }

        //books/delete/15
        public ActionResult Delete(int id)
        {
            BooksRepository r = new BooksRepository();

            r.Delete(id);
            List<BookModel> myBooks = r.GetAll();



            return View("List", myBooks);

        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchModel searchData)
        {
            BooksRepository r = new BooksRepository();

            List<BookModel> foundBooks = r.Search(searchData.Text);

            return View("List", foundBooks);
        }
    }
}