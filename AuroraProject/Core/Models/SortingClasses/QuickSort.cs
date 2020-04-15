using AuroraProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class QuickSort : ISortStrategy
    {
        public List<Gig> SortAcsending(List<Gig> gigs)
        {
            var arr = gigs.ToArray();

            QuickSort.quickSort(arr, 0, arr.Length - 1);
            QuickSort.partition(arr, 0, arr.Length - 1);

            var newList = arr.ToList();
            return newList;
        }

        public List<Gig> SortDescending(List<Gig> gigs)
        {
            var arr = gigs.ToArray();

            QuickSort.quickSort(arr, 0, arr.Length - 1);
            QuickSort.partition(arr, 0, arr.Length - 1);

            var newList = arr.ToList();
            newList.Reverse();
            return newList;
        }

        static void quickSort(Gig[] arr, int low, int high)
        {
            if (low < high)
            {

                /* pi is partitioning index, arr[pi] is  
                now at right place */
                int pi = partition(arr, low, high);

                // Recursively sort elements before
                // partition and after partition
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
        }

        static int partition(Gig[] arr, int low, int high)
        {
            Gig pivot = arr[high];
            // index of smaller element
            int i1 = (low - 1);
            for (int j = low; j < high; j++)
            {
                // If current element is smaller  
                // than the pivot
                if (arr[j].UserRating < pivot.UserRating)
                {
                    i1++;

                    // swap arr[i] and arr[j]
                    Gig temp = arr[i1];
                    arr[i1] = arr[j];
                    arr[j] = temp;
                }
            }

            // swap arr[i+1] and arr[high] (or pivot)
            Gig temp1 = arr[i1 + 1];
            arr[i1 + 1] = arr[high];
            arr[high] = temp1;

            return i1 + 1;
        }
    }
}