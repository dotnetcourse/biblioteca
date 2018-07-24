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
            var b1 = bookList.First(x => x.Id == id);
            bookList.Remove(b1);

            return View("List", bookList);

            //bool exitAll = false;

            //for (int i = 0; i < 100; i++)
            //{
            //    foreach (BookModel book in bookList)
            //    {
            //        if (book.Name == "mybook")
            //        {
            //            exitAll = true;
            //            break;
            //        }

            //        if (book.Id == id)
            //        {
            //            bookList.RemoveAt(id);

            //        }
            //    }

            //    if (exitAll)
            //    {
            //        break;
            //    }
            //}


        }

        //books/altaction?nume=whitefang&autor=jacklondon
        //public ActionResult AltAction(string nume, string autor)
        //{

        //}
    }
}