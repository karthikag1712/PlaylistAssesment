using Chinook.ClientModels;
using Chinook.Interfaces;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System.Xml;

namespace Chinook.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly ChinookContext dbContext;

        public PlaylistService(ChinookContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<bool> AddTrackstoPlaylist( long TrackId,string CurrentUserId,string PlaylistName)
        {
            try
            {
                var isUserListExists =await dbContext.UserPlaylists.Where(i => i.UserId == CurrentUserId && i.Playlist.Name== PlaylistName).Include(i=>i.Playlist).FirstOrDefaultAsync();
                if(isUserListExists==null)
                {
                    var entityFavList = new Models.Playlist { Name = PlaylistName };
                    dbContext.Playlists.Add(entityFavList);
                    await dbContext.SaveChangesAsync();
                    var entityUserList = new UserPlaylist { PlaylistId = entityFavList.PlaylistId, UserId = CurrentUserId, TrackId= TrackId };
                    dbContext.UserPlaylists.Add(entityUserList);
                    await dbContext.SaveChangesAsync();

                }
                else
                {
                    var entityUserList = new UserPlaylist { PlaylistId = isUserListExists.PlaylistId, UserId = CurrentUserId, TrackId = TrackId };
                    if (isUserListExists != null)
                    {
                        dbContext.Entry(isUserListExists).State = EntityState.Detached;
                    }
                    dbContext.Entry(entityUserList).State = EntityState.Modified;
                    dbContext.UserPlaylists.Add(entityUserList);
                    await dbContext.SaveChangesAsync();

                }
               
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public async Task<List<Models.Playlist>> GetPlaylists(string CurrentUserId)
        {
            try
            {
                return  await dbContext.UserPlaylists.Where(a => a.UserId == CurrentUserId)
                .Include(a => a.Playlist)
                .Select(t => new Models.Playlist()
                {
                    PlaylistId = t.PlaylistId,
                    Name = t.Playlist.Name
               
                }).Distinct().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Models.Playlist> GetPlaylistsById(long PlaylistId)
        {
            try
            {
                return await dbContext.Playlists.Where(a => a.PlaylistId == PlaylistId).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveTrackPlaylist(long trackId, string CurrentUserId, string PlaylistName)
        {
            try
            {
                var isUserListExists = await dbContext.UserPlaylists.Where(i => i.UserId == CurrentUserId && i.Playlist.Name == PlaylistName && i.TrackId==trackId).FirstOrDefaultAsync();
                if (isUserListExists != null)
                {
                    dbContext.UserPlaylists.Remove(isUserListExists);
                }
               
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
