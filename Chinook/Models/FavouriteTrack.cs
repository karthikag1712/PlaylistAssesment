using System.ComponentModel.DataAnnotations;

namespace Chinook.Models
{
    public class FavouriteTrack
    {
       
        public string UserId { get; set; }
        public long PlaylistId { get; set; }
      
      
      
        public long TrackId { get; set; }
       
    }
}
