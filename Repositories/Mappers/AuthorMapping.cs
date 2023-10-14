using AutoMapper;
using BussinessObjects;
using Repositories.ViewModels.Author;
using Repositories.ViewModels.BookAuthor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Mappers
{
    public partial class MapperConfigs : Profile
    {
        void AddAuthorConfig()
        {
            CreateMap<Author, AuthorDetailVM>()
                .ForMember(
                    des => des.bookList,
                    opt => opt.MapFrom(
                        src => src.BookAuthors != null && src.BookAuthors.Any() ?
                            GetBookNames(src.BookAuthors)
                            : new List<string>().AsQueryable()
                        ));
            CreateMap<AuthorEditVM, Author>().ReverseMap();
        }

        private IQueryable<string> GetBookNames(IQueryable<BookAuthor> bookAuthors)
        {
            List<string> bookNames = new List<string>();

            foreach (var bookAuthor in bookAuthors)
            {
                if (bookAuthor.Book != null) // Ensure that Product is not null.
                {
                    bookNames.Add(bookAuthor.Book.Title);
                }
            }

            return bookNames.AsQueryable();
        }
    }
}
