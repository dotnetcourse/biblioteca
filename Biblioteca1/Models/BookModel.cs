using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca1.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthorName { get; set; }

        public string ISBN { get; set; }
        
        public int Year { get; set; }
    }
}