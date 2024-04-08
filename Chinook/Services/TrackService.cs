using Chinook.ClientModels;
using Chinook.Interfaces;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services
{
    public class TrackService : ITrackService
    {
        private readonly ChinookContext dbContext;

        public TrackService(ChinookContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<List<PlaylistTrack>> GetTracksByArtistId(long ArtistId, string CurrentUserId)
        {
            try
            {
                var tracks = await dbContext.Tracks.Where(a => a.Album.ArtistId == ArtistId)
             .Include(a => a.Album)
             .Select(t => new PlaylistTrack()
             {
                 AlbumTitle = (t.Album == null ? "-" : t.Album.Title),
                 TrackId = t.TrackId,
                 TrackName = t.Name,
                 // IsFavorite = t.UserPlaylists.Where(p => p.UserPlaylists.Any(up => up.UserId == CurrentUserId && up.TrackId==t.TrackId && up.Playlist.Name == "Favorites")).Any()
                 IsFavorite = t.UserPlaylists.Any(up => (up.UserId == CurrentUserId && up.TrackId == t.TrackId && up.Playlist.Name == "My favourite tracks"))
            })
            .ToListAsync();
                return tracks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PlaylistTrack>> GetTracksByPlaylistId(long PlaylistId)
        {
            try
            {
                var result = from userplay in dbContext.UserPlaylists
                             join track in dbContext.Tracks
                             on userplay.TrackId equals track.TrackId // Assuming Ids match for some reason
                             where userplay.PlaylistId == PlaylistId
                             select (new PlaylistTrack()
                             {
                                 AlbumTitle=track.Album.Title,
                                 ArtistName=track.Album.Artist.Name,
                                 TrackName=track.Name,
                                 TrackId=track.TrackId                             
                             });
                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
