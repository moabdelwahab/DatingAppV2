using System.Text.Json.Serialization;

namespace LinkDev.DatingApp.Core
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain  { get; set; }
        public int PublicId { get; set; }
        public AppUser User { get; set; }
        public int AppUserId { get; set; }
    }
}