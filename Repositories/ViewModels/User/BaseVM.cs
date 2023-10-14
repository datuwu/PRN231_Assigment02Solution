using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ViewModels.User
{
    public class BaseVM
    {
        public string Email { get; set; }
        public string? Source { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public int RoleId { get; set; }
        public int? PublisherId { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
