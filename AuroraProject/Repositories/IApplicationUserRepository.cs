using AuroraProject.Models;

namespace AuroraProject.Repositories
{
    public interface IApplicationUserRepository
    {
        ApplicationUser GetUser(string userId);
    }
}