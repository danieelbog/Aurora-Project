using AuroraProject.Core.Models;
using System.Collections.Generic;

namespace AuroraProject.Core.Repositories
{
    public interface ISpecificIndustryRepository
    {
        IEnumerable<SpecificIndustry> GetSpecificIndustriesPerIndustry(int industryId);
        IEnumerable<SpecificIndustry> GetSpecificIndustries();
        SpecificIndustry GetSpecificIndustry(int? specificIndustryId);

    }
}