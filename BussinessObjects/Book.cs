using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Type { get; set; }
        public int PublisherId { get; set; }
        public double Price { get; set; }
        public string? Advance { get; set; }
        public string? Royalty { get; set; }
        public DateTime? YTDSales { get; set; }
        public string? Note { get; set; }
        public DateTime? PublishedDate { get; set; }

        public Publisher? Publisher { get; set; }
        public IList<BookAuthor>? BookAuthors { get; set; }
        
    }
}
