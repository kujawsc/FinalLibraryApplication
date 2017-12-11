using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLibraryApplication
{
    public class Library
    {
        public int ID {get; set;}
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Series { get; set; }
        public string ISBN { get; set; }

        public Library()
        {

        }

        public Library(int id, string bookTitle, string author, string genre, string series, string ISBN)
        {
            this.ID = id;
            this.BookTitle = bookTitle;
            this.Author = author;
            this.Genre = genre;
            this.Series = series;
            this.ISBN = ISBN;

        }
    }
}
