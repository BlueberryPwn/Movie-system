namespace Movie_system.Models
{
    public class Reviews
    {
        public int ReviewId { get; set; }
        public string? Review { get; set; }
        public string? ReviewRating { get; set; }
        public int UserId { get; set; }
    }
}
