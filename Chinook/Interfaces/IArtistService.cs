using Chinook.Models;

namespace Chinook.Interfaces
{
    public interface IArtistService
    {
        Task<List<Artist>> GetArtists();
        Task<Artist> GetArtistsById(long ArtistId);

        Task<List<Artist>> GetArtistsByName(string Name);
    }
}
