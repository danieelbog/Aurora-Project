using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class BucketSort : ISortStrategy
    {
        public List<Gig> SortAcsending(List<Gig> gigs)
        {
            var sortedList = SortShirts(gigs);
            var listOfGigs = InsertionSortBucket(sortedList);

            return listOfGigs;
        }

        public List<Gig> SortDescending(List<Gig> products)
        {
            var sortedList = SortShirts(products);
            var listOfGigs = InsertionSortBucket(sortedList);

            listOfGigs.Reverse();
            return listOfGigs;
        }

        public static List<Gig> SortShirts(List<Gig> gigs)
        {
            List<Gig> sortedList = new List<Gig>();

            int numOfBuckets = 5;

            //create buckets
            List<Gig>[] buckets = new List<Gig>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<Gig>();
            }

            //Iterate through the passed array and add each integer to the appropriate bucket
            for (int i = 0; i < gigs.Count; i++)
            {
                int bucket = (int)gigs[i].UserRating;
                if (bucket == 0 || bucket == 1)
                    bucket = 0;
                else if (bucket == 2 || bucket == 3)
                    bucket = 1;
                else if (bucket == 4 || bucket == 5)
                    bucket = 2;
                else
                    bucket = 3;

                buckets[bucket].Add(gigs[i]);
            }

            // Sort each bucket, add it to the result
            for (int i = 0; i < numOfBuckets; i++)
            {
                List<Gig> temp = InsertionSortBucket(buckets[i]);
                sortedList.AddRange(temp);
            }

            return sortedList;
        }

        public static List<Gig> InsertionSortBucket(List<Gig> products)
        {
            Gig temp;

            for (int i = 1; i < products.Count; i++)
            {
                // Store current value in a variable
                int currentValue = (int)products[i].UserRating;
                int pointer = i - 1;

                while (pointer >= 0)
                {
                    if (currentValue < (int)products[pointer].UserRating)
                    {
                        temp = products[pointer + 1];
                        products[pointer + 1] = products[pointer];
                        products[pointer] = temp;
                        pointer--;
                    }
                    else break;
                }
            }
            return products;
        }
    }
}