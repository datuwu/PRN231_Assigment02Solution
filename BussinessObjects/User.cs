namespace BussinessObjects
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Source { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public int RoleId { get; set; }
        public int? PublisherId { get; set; }
        public DateTime? HireDate { get; set; }

        public Role Role { get; set; }
        public Publisher? Publisher { get; set; }

    }
}