using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    // Book class
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = true; 
        }
    }

    public class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Book '{book.Title}' added to the library.");
        }

       
        public Book SearchBook(string searchTerm)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    books[i].Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                {
                    return books[i];
                }
            }
            return null;
        }

        public void BorrowBook(string searchTerm)
        {
            Book book = SearchBook(searchTerm);
            if (book != null)
            {
                if (book.IsAvailable)
                {
                    book.IsAvailable = false;
                    Console.WriteLine($"You have borrowed '{book.Title}'.");
                }
                else
                {
                    Console.WriteLine($"Sorry, '{book.Title}' is currently not available.");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void ReturnBook(string searchTerm)
        {
            Book book = SearchBook(searchTerm);
            if (book != null)
            {
                if (!book.IsAvailable)
                {
                    book.IsAvailable = true;
                    Console.WriteLine($"You have returned '{book.Title}'.");
                }
                else
                {
                    Console.WriteLine($"The book '{book.Title}' was not borrowed.");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }

    // Main class to test the functionality
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            Console.WriteLine("\nSearching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); 

            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); 

            Console.ReadLine();
        }
    }
}
