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
            
            CreateMap<AuthorEditVM, Author>().ReverseMap();
        }

        
    }
}
