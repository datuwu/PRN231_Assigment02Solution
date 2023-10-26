﻿using BussinessObjects;
using Repositories.ViewModels.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IAuthorService
    {
        IQueryable<Author> GetAll();
    }
}
