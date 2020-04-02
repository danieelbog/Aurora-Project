using AuroraProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Models
{
    public class BubbleSort : ISortStrategy
    {
        public List<Gig> SortAcsending(List<Gig> gigs)
        {
            Gig temp;
            for (int j = 0; j <= gigs.Count - 2; j++)
            {
                for (int i = 0; i <= gigs.Count - 2; i++)
                {
                    if (gigs[i].UserRating > gigs[i + 1].UserRating)
                    {
                        temp = gigs[i + 1];
                        gigs[i + 1] = gigs[i];
                        gigs[i] = temp;
                    }
                }
            }

            return gigs;
        }

        public List<Gig> SortDescending(List<Gig> gigs)
        {
            Gig temp;
            for (int j = 0; j <= gigs.Count - 2; j++)
            {
                for (int i = 0; i <= gigs.Count - 2; i++)
                {
                    if (gigs[i].UserRating < gigs[i + 1].UserRating)
                    {
                        temp = gigs[i + 1];
                        gigs[i + 1] = gigs[i];
                        gigs[i] = temp;
                    }
                }
            }

            return gigs;
        }
    }
}