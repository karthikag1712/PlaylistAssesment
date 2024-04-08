using Chinook.Models;

namespace Chinook.Interfaces
{
    public interface IAlbumService
    {
        Task<List<Album>> GetAlbumsByArtistId(int ArtistId);
    }
}
