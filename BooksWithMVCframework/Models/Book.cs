using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksWithMVCframework.Models
{
    public class Book
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

        public byte categoriesId { get; set; }
        
        public Categories categories { get; set; }

        public DateTime AddedOn { get; set; }

        public Book()
        {
            AddedOn = DateTime.Now;
        }
    
          
    }
}