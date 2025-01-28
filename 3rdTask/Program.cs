using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter");

            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter");

            Console.ReadLine();
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Availability { get; set; }


        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Availability = true;
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
            Console.WriteLine($"Added \"{book.Title}\" by {book.Author} to the library.");
        }


        public Book SearchBook(string keyword)
        {
            keyword = keyword.ToLower();

            for (int i = 0; i < books.Count; i++)
            {
                var book = books[i];

                if (book.Title.ToLower().Contains(keyword) || book.Author.ToLower().Contains(keyword))
                {
                    return book;
                }
            }
            return null;
        }



        public void BorrowBook(string title)
        {
            Book book = SearchBook(title);
            if (book == null)
            {
                Console.WriteLine($"Book \"{title}\" is not found in the library.");
            }
            else if (!book.Availability)
            {
                Console.WriteLine($"Book \"{book.Title}\" is already borrowed.");
            }
            else
            {
                book.Availability = false;
                Console.WriteLine($"You have borrowed \"{book.Title}\" by {book.Author}.");
            }
        }

        public void ReturnBook(string title)
        {
            Book book = SearchBook(title);
            if (book == null)
            {
                Console.WriteLine($"Book \"{title}\" is not found in the library.");
            }
            else if (book.Availability)
            {
                Console.WriteLine($"Book \"{book.Title}\" was not borrowed.");
            }
            else
            {
                book.Availability = true;
                Console.WriteLine($"You have returned \"{book.Title}\" by {book.Author}.");
            }
        }
    }
}
