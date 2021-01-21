using System;
using Library.Classes;
using System.Collections.Generic;

namespace Library
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            List<Book> bookBag = new List<Book>();
            Library<Book> myLibrary = new Library<Book>();
            LoadBooks(myLibrary);
            MainMenu(myLibrary, bookBag);
        }

        public static void MainMenu(Library<Book> library, List<Book> bookBag)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Hello what would you like to do today:\n" +
                                  "1 - View all books available in library.\n" +
                                  "2 - Add a new book to our library.\n" +
                                  "3 - Borrow a book from the library.\n" +
                                  "4 - Return a book.\n" +
                                  "5 - View all books you have checked out.\n" +
                                  "6 - Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        ViewBooks(library);
                        Pause();
                        break;
                    case "2":
                        AddBook(library);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("What book would you like to borrow:");
                        Borrow(Console.ReadLine(), library, bookBag);
                        Pause();
                        break;
                    case "4":
                        Console.Clear();
                        ReturnBook(bookBag, library);
                        Pause();
                        break;
                    case "5":
                        Console.Clear();
                        ViewBookBag(bookBag);
                        Pause();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("You did not select a valid number between 1-6");
                        break;
                }
            }
        }
        public static void Pause()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public static void ViewBookBag(List<Book> bookBag)
        {
            foreach(Book book in bookBag)
                Console.WriteLine($"Book: {book.Title}  Author: {book.Author}  Genre: {book.Author}");
        }

        public static void ViewBooks(Library<Book> library)
        {
            for(int i = 0; i < library.bookCount; i++)
                Console.WriteLine($"{library.books[i].Title}  Author: {library.books[i].Author.Name}  Genre: {library.books[i].Genre}");
        }
    
        public static void AddBook(Library<Book> library)
        {
            Console.WriteLine("Please enter the title of the book:");
            string title = Console.ReadLine();

            Console.WriteLine("Please enter the Authors first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Please enter the Authors last name:");
            string lastName = Console.ReadLine();

            //https://stackoverflow.com/questions/972307/how-to-loop-through-all-enum-values-in-c
            foreach (Genre genre in Enum.GetValues(typeof(Genre)))
            Console.WriteLine($"{genre.GetHashCode()} {genre}");
            Console.WriteLine("Please select the number of the genre for this book:");

            int input = int.Parse(Console.ReadLine());
            //https://stackoverflow.com/questions/17486474/find-total-number-of-items-defined-in-an-enum-c-sharp
            int enumLength = Enum.GetNames(typeof(Genre)).Length -1;
            while (input < 0 || input > enumLength)
            {
                Console.Clear();
                Console.WriteLine($"Please select a number between 0 and {enumLength}");
                foreach (Genre genre in Enum.GetValues(typeof(Genre)))
                Console.WriteLine($"{genre.GetHashCode()} {genre}");
                input = Convert.ToInt32(Console.ReadLine());
            }

            Genre selectedGenre = new Genre();

            foreach(Genre genre in Enum.GetValues(typeof(Genre)))
            {
                if (genre.GetHashCode() == input) selectedGenre = genre;
            }

            Author author = new Author(firstName, lastName);
            Book newBook = new Book(title, author, selectedGenre);
            library.Add(newBook);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookBag"></param>
        /// <param name="library"></param>
        public static void ReturnBook(List<Book> bookBag, Library<Book> library)
        {
           
            Dictionary<int, Book> yourBooks = new Dictionary<int, Book>();

            for(int i = 0; i < bookBag.Count; i++)
            {
                yourBooks.Add(i, bookBag[i]);
                Console.WriteLine($"{i} - {bookBag[i].Title}");
            }

            if (bookBag.Count > 0)
            {
                int userInput = -1;
                while (userInput < 0 || userInput > bookBag.Count - 1)
                {
                    Console.WriteLine("Select the number of the book you would like to return:");
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
              
                Book returnBook = yourBooks[userInput];
                bookBag.Remove(returnBook);
                library.Add(returnBook);
            }
            else
                Console.WriteLine("You do not have any books checked out.");

        }

        public static void Borrow(string title, Library<Book> library, List<Book> bookBag)
        {
            Book yourBook = GetBook(title, library);
            if (yourBook != null)
            {
                bookBag.Add(yourBook);
                library.Remove(yourBook);
            }
        }

        public static Book GetBook(string title, Library<Book> library)
        {
            for (int i = 0; i < library.Count(); i++)
            {
                if (library.books[i].Title == title) return library.books[i];
            }
            Console.WriteLine($"{title} was not found in the library");
            return null;
        }

        public static void LoadBooks(Library<Book> myLibrary)
        {
            Author me = new Author("David");
            Book book1 = new Book("book1", me, Genre.Childrens);
            Book book2 = new Book("book2", me, Genre.Fiction);
            Book book3 = new Book("book3", me, Genre.Horror);
            Book book4 = new Book("book4", me, Genre.Romance);
            Book book5 = new Book("book5", me, Genre.SciFi);

            myLibrary.Add(book1);
            myLibrary.Add(book2);
            myLibrary.Add(book3);
            myLibrary.Add(book4);
            myLibrary.Add(book5);

        }


    }
}
