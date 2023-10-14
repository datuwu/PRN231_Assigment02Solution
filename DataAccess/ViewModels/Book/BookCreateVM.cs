namespace DataAccess.ViewModels
{
    public class BookCreateVM : BaseVM
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}