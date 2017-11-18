using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace bookstore.Models
{
    public class BookStoreContext : DbContext
    {
        public DbSet<BookViewModel> Books { get; set; }
        public DbSet<AuthorViewModel> Authors { get; set; }
        public DbSet<BookAuthorViewModel> BookAuthors { get; set; }

        public BookStoreContext()
            : base("dbook")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookViewModel>().ToTable("book");


            modelBuilder.Entity<AuthorViewModel>().ToTable("author");
            modelBuilder.Entity<BookAuthorViewModel>().ToTable("book_author");

            base.OnModelCreating(modelBuilder);
        }
    }
}