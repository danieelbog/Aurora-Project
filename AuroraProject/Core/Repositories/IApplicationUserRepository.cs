using AuroraProject.Core.Models;

namespace AuroraProject.Core.Repositories
{
    public interface IApplicationUserRepository
    {
        ApplicationUser GetUser(string userId);
    }
}