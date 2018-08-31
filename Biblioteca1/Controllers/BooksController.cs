using Biblioteca.DAL;
using Biblioteca.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult List()
        {
            BooksRepository r = new BooksRepository();

            List<BookModel> myBooks = r.GetAll();

            return View();
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

        public ActionResult Download()
        {
            BooksRepository r = new BooksRepository();

            List<BookModel> bookList = r.GetAll();
            string listString = JsonConvert.SerializeObject(bookList);
            
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            sw.Write(listString);
            sw.Flush();
            ms.Position = 0;

            return File(ms, "application/force-download", "exportbiblioteca.json");
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase fileContent)
        {
            BooksRepository r = new BooksRepository();

            string extension = Path.GetExtension(fileContent.FileName);
            
            if (extension.ToLower() == ".json")
            {
                StreamReader sr = new StreamReader(fileContent.InputStream);
                string body = sr.ReadToEnd();

                //System.IO.File.AppendAllText("c:\\myfile.json", body);
                //string myFileData = System.IO.File.ReadAllText("c:\\myfile.json");


                //var myFileStream = System.IO.File.Open("c:\\myfile.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
                //var myFileStream = System.IO.File.OpenRead("c:\\myfile.json");
                //StreamReader fileReader = new StreamReader(myFileStream);
                //fileReader.ReadLine();

                var books = JsonConvert.DeserializeObject<IEnumerable<BookModel>>(body).ToList();
                
                foreach (BookModel b in books)
                {
                    b.Id = 0;
                    r.Add(b);
                }
            }
            else if (extension.ToLower() == ".csv")
            {
                StreamReader sr = new StreamReader(fileContent.InputStream);
                while (!sr.EndOfStream)
                {
                    string row = sr.ReadLine();
                    string[] fields = row.Split(',', ';');
                    BookModel b = new BookModel
                    {
                        Name = fields[0].Trim().Trim('"'),
                        AuthorName = fields[1].Trim().Trim('"'),
                        ISBN = fields[2].Trim().Trim('"'),
                        Year = int.Parse(fields[3].Trim().Trim('"'))
                    };

                    r.Add(b);
                }
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            BooksRepository r = new BooksRepository();

            return View(r.GetById(id));
        }

    }
}