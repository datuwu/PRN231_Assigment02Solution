using Repositories.ViewModels.Author;
using Repositories.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ViewModels.BookAuthor
{
    public class BookAuthorVM : BaseVM
    {
        public BookDetailVM bookInfo { get; set; }
        public AuthorDetailVM authorInfo { get; set; }
    }
}
