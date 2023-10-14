using BussinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ViewModels.Publisher
{
    public class BaseVM
    {
        [Required(ErrorMessage = "Required publisher name")]
        public string PublisherName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string Country { get; set; }

    }
}
