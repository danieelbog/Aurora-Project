using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
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

        public static List<Auction> SortDescendingBet(List<Auction> autctions)
        {
            Auction temp;
            for (int j = 0; j <= autctions.Count - 2; j++)
            {
                for (int i = 0; i <= autctions.Count - 2; i++)
                {
                    if (autctions[i].Bet < autctions[i + 1].Bet)
                    {
                        temp = autctions[i + 1];
                        autctions[i + 1] = autctions[i];
                        autctions[i] = temp;
                    }

                    //if (autctions[i].SpecificIndustryID < autctions[i + 1].SpecificIndustryID)
                    //{
                    //    temp = autctions[i + 1];
                    //    autctions[i + 1] = autctions[i];
                    //    autctions[i] = temp;
                    //}
                }
            }

            return autctions;
        }
    }
}