using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects
{
    [PrimaryKey(nameof(AuthorId), nameof(BookId))]
    public class BookAuthor
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public string AuthorOrder { get; set; }
        public int RoyalityPercentage { get; set; }

        public Book Book { get; set; }
        public Author? Author { get; set; }
    }
}
