using AutoMapper;
using BussinessObjects;
using Repositories.UnitOfWork;
using Repositories.ViewModels.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly IMapper _mapper;

        public AuthorService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IQueryable<Author> GetAll()
        {
            var authors = _unitOfWork.AuthorRepository.Get();

            if (authors == null)
            {
                throw new NullReferenceException("Authors not found");
            }

            
            return authors;
        }
    }
}
