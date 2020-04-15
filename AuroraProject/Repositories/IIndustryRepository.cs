using AuroraProject.Models;
using System.Collections.Generic;

namespace AuroraProject.Repositories
{
    public interface IIndustryRepository
    {
        IEnumerable<Industry> GetIndustries();
    }
}