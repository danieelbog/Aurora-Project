using AuroraProject.Models;
using System.Collections.Generic;

namespace AuroraProject.Repositories
{
    public interface IMembershipTypeRepository
    {
        IEnumerable<MembershipType> GetMembershipTypes();
    }
}