using Biblioteca1.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca1
{
    public class BooksRepository
    {
        public void Add(BookModel book)
        {
            using (var db = new LiteDatabase(@"c:\db\Biblioteca.db"))
            {
                // Get customer collection
                var books = db.GetCollection<BookModel>("books");

                books.Insert(book);
            }
            
        }

        public List<BookModel> GetAll()
        {
            try
            {
                using (var db = new LiteDatabase(@"c:\db\Biblioteca.db"))
                {
                    // Get customer collection
                    var books = db.GetCollection<BookModel>("books");

                    return books.FindAll().ToList();
                }
            }catch(Exception ex)
            {
                //log exceptions

                throw new ApplicationException("Eroare la conectarea la baza de date", ex);
            }
        }

        public void Delete(int id)
        {
            var db = new LiteDatabase(@"c:\db\Biblioteca.db");
            var books = db.GetCollection<BookModel>("books");

            books.Delete(id);

        }

        public List<BookModel> Search(string text)
        {
            var db = new LiteDatabase(@"c:\db\Biblioteca.db");
            var books = db.GetCollection<BookModel>("books");

            return books.Find(
                    Query.Or(
                        Query.Contains("Name", text), 
                        Query.Contains("AuthorName", text)
                    )
                ).ToList();
        }
    }
}