using AuroraProject.Core.Models;
using System.Collections.Generic;

namespace AuroraProject.Core.Repositories
{
    public interface IIndustryRepository
    {
        IEnumerable<Industry> GetIndustries();
    }
}