using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class Sorter
    {
        public List<Gig> Gigs { get; set; }

        // STRATEGY PATTERN FOR SORTING AND PRINTING
        public ISortStrategy _sortStrategy { get; set; }
        public void SetSortingStrategy(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public List<Gig> SortAllGigs(List<Gig> gigs)
        {
            var sortedDescendingList = _sortStrategy.SortDescending(gigs);

            //UNCOMMENT THIS CODE TO RUN IN ASSCENDING MODE
            //var sortedAscendingList = _sortStrategy.SortDescending(gigs);

            return sortedDescendingList;

        }

        public static List<Gig> SortLogic(List<Gig> gigs)
        {
            var sorter = new Sorter();

            if (gigs.Count < 100)
            {
                sorter.SetSortingStrategy(new BubbleSort());
                sorter.SortAllGigs(gigs);
            }
            else if (gigs.Count < 1000)
            {
                sorter.SetSortingStrategy(new BucketSort());
                sorter.SortAllGigs(gigs);
            }
            else
            {
                sorter.SetSortingStrategy(new QuickSort());
                sorter.SortAllGigs(gigs);
            }

            return gigs;
        }

    }
}