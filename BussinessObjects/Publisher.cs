using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects
{
    public class Publisher
    {
        public int Id { get; set; }
        public string PublisherName { get; set;}
        public string? City { get; set; }
        public string? State { get; set; }
        public string Country { get; set; }
        
        public virtual IList<User>? Users { get; set; }
        public virtual IList<Book>? Books { get; set; }
    }
}
