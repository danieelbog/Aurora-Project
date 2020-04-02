using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraProject.Interfaces
{
    public interface ISortStrategy
    {
        List<Gig> SortAcsending(List<Gig> gigs);
        List<Gig> SortDescending(List<Gig> gigs);
    }
}
