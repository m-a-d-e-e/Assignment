using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemoApp
{
    public class BookEventArgs : EventArgs
    {
        public Book Book { get; set; }
    }

   
    public delegate void BookPublishedEventHandler(object source, BookEventArgs args);

    public class Publisher
    {
        
        public event BookPublishedEventHandler BookPublished;

        public void Publish(Book book )
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"Book published ... Title : {book.Title}  Author : {book.Author} ");
            OnBookPublished(book);
        }

        protected virtual void OnBookPublished(Book book)
        {
            if(BookPublished != null)
            {
                BookPublished(this, new BookEventArgs() {Book = book});
            }
        }
        
    }
}
