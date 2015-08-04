using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters;

namespace PotterKata1
{
    public static class PriceCalculator
    {
        private const double BaseBookPrice = 8.0;

        public static double CalculatePrice(params int[] books)
        {
            var numOfDifferentKindsOfBooks =
                books.GroupBy(book => book).Select(sameBooks => sameBooks.Count()).OrderBy(numOfBooks => numOfBooks);
            var setsOfBooks = numOfDifferentKindsOfBooks.Aggregate(new List<int>(),
                (sets, i) =>
            {
                sets.Add(i - sets.Sum());
                return sets;
            }
            );
            var price = setsOfBooks.Select((set ,i) => set*BaseBookPrice* (numOfDifferentKindsOfBooks.Count()-i)*GetDiscountFor(numOfDifferentKindsOfBooks.Count() - i)).Sum();

            return price;
        }

        private static double GetDiscountFor(int distinctBooks)
        {
            switch (distinctBooks)
            {
                case 2:
                    return 0.95;
                case 3:
                    return 0.9;
                case 4:
                    return 0.8;
                case 5:
                    return 0.75;
            }

            return 1.0;
        }
    }
}