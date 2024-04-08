using Chinook.Models;

namespace Chinook.Interfaces
{
    public interface IPlaylistService
    {
        Task<List<Playlist>> GetPlaylists(string CurrentUserId);
        Task<bool> AddTrackstoPlaylist(long trackId, string CurrentUserId, string PlaylistName);
        Task<Playlist> GetPlaylistsById(long PlaylistId);
        Task<bool> RemoveTrackPlaylist(long trackId, string CurrentUserId, string PlaylistName);

    }
}
