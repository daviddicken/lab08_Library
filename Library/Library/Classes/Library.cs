using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Library.Classes
{
    public class Library<T> : IEnumerable
    {
        public T[] books = new T[5];
        public int bookCount = 0;

        public void Add(T book)
        {
            if(bookCount == books.Length)
            {
                Array.Resize(ref books, books.Length * 2);
            }
            books[bookCount++] = book;
        }

        //iterate through array
        //if book is found
        // remove book
        // decrement bookcounter
        // move all following books up 1
        public void Remove(T book)
        {
            bool flag = false;
            
            for(int i = 0; i < bookCount; i++)
            {
                if (books[i].Equals(book))
                {
                    flag = true;
                    //Console.WriteLine($"{book} was removed.");
                }
                if (flag && i < books.Length - 1) books[i] = books[i + 1];
            }
            if (flag) bookCount--;
           // else Console.WriteLine($"{book} was not found");
            
        }
        public int Count()
        {
            return bookCount;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < bookCount; i++) 
                yield return books[i];
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();       
    }
}
