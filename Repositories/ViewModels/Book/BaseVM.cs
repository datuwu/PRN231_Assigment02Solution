using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ViewModels.Book
{
    public class BaseVM
    {
        [Required(ErrorMessage = "Required book title")]
        public string Title { get; set; }
        public string? Type { get; set; }
        [Required(ErrorMessage ="Require publisher")]
        public int PublisherId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than zero.")]
        [Required(ErrorMessage = "Required book price")]
        public double Price { get; set; }
        public string? Advance { get; set; }
        public string? Royalty { get; set; }
        public DateTime? YTDSales { get; set; }
        public string? Note { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
