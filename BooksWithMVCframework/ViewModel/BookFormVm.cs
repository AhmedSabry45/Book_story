using BooksWithMVCframework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksWithMVCframework.ViewModel
{
    public class BookFormVm
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(125)]
        public string Author { get; set; }


        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }


        [Display(Name ="Category")]
        public byte categoriesId { get; set; }
        
        public IEnumerable<Categories> categories { get; set; } 
    }
}