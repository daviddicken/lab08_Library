using System;
using Xunit;
using Library;
using Library.Classes;


namespace LibraryTest
{
    public class UnitTest1
    {
        [Fact]
        public void AddBookTest()
        {
            Library<Book> library = new Library<Book>();
            Book book = new Book();
            library.Add(book);

            Assert.Equal(1, library.bookCount);
        }

        [Fact]
        public void RemoveBookTest()
        {
            Library<Book> library = new Library<Book>();
            Book book = new Book();
            library.Add(book);
            Assert.Equal(1, library.bookCount);
            library.Remove(book);
            Assert.Equal(0, library.bookCount);
        }
        [Fact]
        public void BadRemoveBookTest()
        {
            Library<Book> library = new Library<Book>();
            Book book = new Book();
            Book book2 = new Book();
            library.Add(book);
            library.Remove(book2);
            Assert.Equal(1, library.bookCount);

        }
        [Fact]
        public void BookAuthorPropTest()
        {
            Book testBook = new Book();
            Author testAuthor = new Author("testAuthor");
            testBook.Author = testAuthor;

            Assert.Equal("testAuthor", testBook.Author.Name);
        }
        [Fact]
        public void BookTitlePropTest()
        {
            Book testBook = new Book();
            testBook.Title = "testBook";

            Assert.Equal("testBook", testBook.Title);
        }
        [Fact]
        public void BookGenrePropTest()
        {
            Book testBook = new Book();
            testBook.Genre = Genre.Childrens;

            Assert.Equal(Genre.Childrens, testBook.Genre);
        }

        [Fact]
        public void AuthorPropTest()
        {
            Author testAuthor = new Author();
            testAuthor.Name = "testAuthor";
            Assert.Equal("testAuthor", testAuthor.Name);
        }
  
        [Fact]
        public void NoBooksToGetTest()
        {
            Library<Book> library = new Library<Book>();
            Book book = new Book();
            library.Add(book);

            Assert.Null(Program.GetBook("badBook", library));
        }
    }
}
