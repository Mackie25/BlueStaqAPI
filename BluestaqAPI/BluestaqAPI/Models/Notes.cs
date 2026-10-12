namespace BluestaqAPI.Models
{
    public class Notes
    {
        public int Id { get; set; }
        public string? Note { get; set; }
        public int? UserId { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
