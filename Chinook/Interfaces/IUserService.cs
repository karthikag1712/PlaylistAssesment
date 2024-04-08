using System.Security.Claims;

namespace Chinook.Interfaces
{
    public interface IUserService
    {
        Task<string> GetUser();
    }
}
