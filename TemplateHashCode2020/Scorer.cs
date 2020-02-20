using System;
using System.Collections.Generic;
using System.Linq;

namespace TemplateHashCode2020
{
    public static class Scorer
    {
        public static int ComputeScore(SolutionInstance po, ProblemInstance problem)
        {
            var bookIdsScanned = new HashSet<int>();
            var effectiveLibraryTimes = new Dictionary<int, int>();

            // Compute effective signup times
            var currentTime = 0;
            foreach (var library in po.SignUpLibraryList)
            {
                var timeToSignUp = library.TimeToSignUp;
                var libraryId = library.Id;

                currentTime += timeToSignUp;

                var usefulTime = problem.NumberOfDays - currentTime;
                if (usefulTime > 0)
                {
                    effectiveLibraryTimes.Add(libraryId, usefulTime);
                }
                else
                {
                    Console.WriteLine($"Library {libraryId} is useless as signed up too late.");
                }
            }

            // Compute really shipped book
            foreach (var library in po.SignUpLibraryList)
            {
                var libraryId = library.Id;
                var effectiveLibraryCapacity = library.ShippingCapacity * effectiveLibraryTimes[libraryId];

                foreach (var book in po.ShippingOrders[libraryId].Take(effectiveLibraryCapacity))
                {
                    bookIdsScanned.Add(book);
                }
            }

            return bookIdsScanned.Sum(bookId => problem.Books[bookId].Value);
        }
    }
}