using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Class4Website.Models
{
    public enum Genre { Novel, Biography, Classics, Others}
    public class Book
    {
        public int BookId { get; set; }
        [Required, StringLength(40)]
        public string Title { get; set; }

        [EnumDataType(typeof(Genre)) ]
        public Genre Genre { get; set; }

        [Required, Column(TypeName ="money"), Display(Name ="Cover Price (Tk.)"), DisplayFormat(DataFormatString ="{0:0.00}", ApplyFormatInEditMode =true) ]
        public decimal CoverPrice { get; set; }

    }
    public class BookDbContext: DbContext
    {
        //public BookDbContext() {
        //    Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BookDbContext>());
        //}

        public BookDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DbSet<Book> Books { get; set;}    
    }
    public class DbInitializer: DropCreateDatabaseIfModelChanges<BookDbContext>
    {
        protected override void Seed(BookDbContext context)
        {
            context.Books.AddRange(new Book[] { 
             new Book{Title="Bye Bye", Genre=Genre.Novel, CoverPrice=700.00M},
               new Book{Title="Come Come", Genre=Genre.Novel, CoverPrice=1000.00M}

            });
            context.SaveChanges();
        }
    }
}