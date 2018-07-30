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

        //books/altaction?nume=whitefang&autor=jacklondon
        //public ActionResult AltAction(string nume, string autor)
        //{

        //}
    }
}