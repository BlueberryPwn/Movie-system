namespace Movie_system.Models
{
    public class Reviews
    {
        public int ReviewId { get; set; }
        public string? ReviewName { get; set; }
        public int ReviewRating { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
    }
}
