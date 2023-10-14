using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ViewModels.BookAuthor
{
    public class BaseVM
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public string AuthorOrder { get; set; }
        public int RoyalityPercentage { get; set; }
    }
}
