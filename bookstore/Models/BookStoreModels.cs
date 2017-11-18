using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookstore.Models
{
    public class BookViewModel
    {
        [Key]
        public int BookID { get; set; }

        [Required(ErrorMessage = "It cannot be empty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "It cannot be empty")]
        [Display(Name = "Date Edition")]
        [DataType(DataType.Date)]
        public DateTime DateEdition { get; set; }

        public virtual ICollection<BookAuthorViewModel> BookAuthors { get; set; }
    }

    public class AuthorViewModel
    {
        [Key]
        public int AuthorID { get; set; }
        public string Name { get; set; }
    }

    public class BookAuthorViewModel
    {
        [Key]
        public int BookAuthorID { get; set; }
        public int BookID { get; set; }
        public virtual BookViewModel Book { get; set; }
        public int AuthorID { get; set; }
        public virtual AuthorViewModel Author { get; set; }
    }
}