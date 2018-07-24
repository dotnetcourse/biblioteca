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
            using (var db = new LiteDatabase(@"c:\db\Biblioteca.db"))
            {
                // Get customer collection
                var books = db.GetCollection<BookModel>("books");

                return books.FindAll().ToList();
            }
        }
    }
}