using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book() { Author = "Nicolus", Title = "Adventures of tintin" };

            Readers reader1 = new Readers("Madee");
            Readers reader2 = new Readers("Zahraa");
            Readers reader3 = new Readers("Bushra");

            Publisher publisher = new Publisher();
            BookEventArgs bookEvent = new BookEventArgs();
            

            publisher.BookPublished += reader1.OnBookPublished;              
            publisher.BookPublished += reader2.OnBookPublished;
            publisher.BookPublished += reader3.OnBookPublished;


            publisher.Publish(book);                                        
            publisher.Publish(new Book() { Author = "J.K. Rowling", Title = "Harry Potter" });

            //whenever the Publisher class publishes a Book the readers who have subscribed to the publisher get notified

            Console.ReadLine();
        }
    }

    class Readers   //subscriber  
    {
        public string ReaderName { get; set; }

        public Readers(string name)
        {
            ReaderName = name;
        }

        public void OnBookPublished(object source, BookEventArgs args)
        {
            Console.WriteLine($"Sending notification to {ReaderName} for book with Title --> {args.Book.Title} ..........");
        }
    }
}
