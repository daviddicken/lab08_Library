# Lab08-Library

**Author**: David Dicken

## Overview
This program creates a library and auto populates it with 5 books. It also creates an empty book bag that the user can put checked out books in.
The user will see a menu and be asked to select a number coresponding with which action they would like to do. The actions are:
1- View all books that the library has available for checkout.
2- Add a new book to the library.
3- Checkout a book from the library.
4- Return a book to the library.
5- View all books the user has checked out from the library.
6- Exit the program.

## Walk Through
* When you open this program you will be asked what you would like to do today. Please select a number between 1-6
* If you select 1 a list of all the books available for checkout will be displayed. Press any key to return to the main menu.
* If you select 2 you will be asked to enter the title of the new book you would like to add to the library.
  Then you will be asked for the authors first name and then the authors last name.
  Finally you will be asked to select one of the genres that the book should belong to. Please enter the number that matches the genre of your choice.
* If 3 is selected you will be asked what book you would like to check out from the library. If you select a book that is not in the library you will recieve a message
  notifing you that the book could not be found. If your book was found it will be removed from the library and put into you book bag,
* If 4 is selected you will be shown a list of the books in your book bag and asked to select the number of the book you would like to return to the library.
* If 5 is selected you will be shown a list of all the books you have checked out



## Example
Hello what would you like to do today:  
1 - View all books available in library.  
2 - Add a new book to our library.  
3 - Borrow a book from the library.  
4 - Return a book.  
5 - View all books you have checked out.  
6 - Exit  

## Architecture
This app was built with Visual Studio using C#.
