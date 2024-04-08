using Chinook.ClientModels;
using Chinook.Models;

namespace Chinook.Interfaces
{
    public interface ITrackService
    {
        Task<List<PlaylistTrack>> GetTracksByArtistId(long ArtistId,string CurrentUserId);
        Task<List<PlaylistTrack>> GetTracksByPlaylistId(long PlaylistId);
    }
}
