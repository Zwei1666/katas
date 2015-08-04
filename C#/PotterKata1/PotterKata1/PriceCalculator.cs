using System;
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
            var differentBookSetsCardinalities =
                books.GroupBy(bookType => bookType).Select(sameBooks => sameBooks.Count()).OrderByDescending(numOfBooks => numOfBooks);
            var cardinalitiesOfSetsOfGroupedDiscountBookSets = 
                differentBookSetsCardinalities
                .Zip( differentBookSetsCardinalities.Skip(1).Concat(new [] {0}), (i, next) => i - next)
                .Select((numOfSets, i) => new GroupedSet {Cardinality = i+1, Count = numOfSets} );
            var totalPrice =
                cardinalitiesOfSetsOfGroupedDiscountBookSets.Select(sets => sets.Count * sets.Cardinality * BaseBookPrice * GetDiscountFor(sets.Cardinality))
                    .Sum();

            return totalPrice;
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

    public struct GroupedSet
    {
        public int Cardinality;
        public int Count;
    }
}