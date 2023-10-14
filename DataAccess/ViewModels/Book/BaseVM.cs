namespace DataAccess.ViewModels
{
    public class BaseVM
    {
        public string Title { get; set; }
        public string? Type { get; set; }
        public int PublisherId { get; set; }
        public double Price { get; set; }
        public string? Advance { get; set; }
        public string? Royalty { get; set; }
        public DateTime? YTDSales { get; set; }
        public string? Note { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}