using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class Book
    {
        public String Title { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        

        public Book() { }
        public Book(String title, String authorFirst, String authorLast, Genre genre)
        {
            Author = new Author(authorFirst, authorLast);
            Title = title;
            Genre = genre;          
        }
        public Book(String title, Author author, Genre genre)
        {
            Author = author;
            Title = title;
            Genre = genre;
        }



    }

    enum Genre
    {
        SciFi,
        Fiction,
        Childrens,
        Horror,
        Romance
    }
}
