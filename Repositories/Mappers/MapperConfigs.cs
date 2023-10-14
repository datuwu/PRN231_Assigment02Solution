using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Mappers
{
    public partial class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            AddAuthorConfig();
        }
    }
}
