using Chinook.Interfaces;
using Chinook.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chinook.Services
{
    public class ArtistService : IArtistService
    {
        private readonly ChinookContext dbContext;

        public ArtistService(ChinookContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<List<Artist>> GetArtists()
        {
            try
            {
                return await dbContext.Artists.ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Artist> GetArtistsById(long ArtistId)
        {
            try
            {
                return await dbContext.Artists.SingleOrDefaultAsync(a => a.ArtistId == ArtistId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Artist>> GetArtistsByName(string Name)
        {
            try
            {
                return await dbContext.Artists.Where(a => a.Name.ToLower().Contains(Name.Trim().ToLower())).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
