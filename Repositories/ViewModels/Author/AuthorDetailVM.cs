using Repositories.ViewModels.Book;
using Repositories.ViewModels.BookAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ViewModels.Author
{
    public class AuthorDetailVM : BaseVM
    {
        public int Id { get; set; }
        public List<string>? bookList { get; set; }
    }
}
