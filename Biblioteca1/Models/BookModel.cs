using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca1.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required()]
        [Display(Name="Titlu")]
        public string Name { get; set; }
        
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Numele autorului tre sa fie intre 3 si 50 caractere")]
        [Required()]
        [Display(Name = "Nume autor")]
        public string AuthorName { get; set; }
        
        public string ISBN { get; set; }

        [Range(-2000, 2100)]
        [Required]
        [Display(Name = "Anul publicatie")]
        public int Year { get; set; }
    }
}