using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksWithMVCframework.Models
{

    [Table("Category")]
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        //for filteration dropdownlist
        public bool Action { get; set; }
    }
}