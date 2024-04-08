using Chinook.Interfaces;
using Chinook.Models;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly ChinookContext dbContext;

        public AlbumService(ChinookContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<List<Album>> GetAlbumsByArtistId(int ArtistId)
        {
            try
            {
                return await dbContext.Albums.Where(a => a.ArtistId == ArtistId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
