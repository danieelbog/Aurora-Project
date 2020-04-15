using AuroraProject.Core.Models;
using System.Collections.Generic;

namespace AuroraProject.Core.Repositories
{
    public interface IMembershipTypeRepository
    {
        IEnumerable<MembershipType> GetMembershipTypes();
    }
}