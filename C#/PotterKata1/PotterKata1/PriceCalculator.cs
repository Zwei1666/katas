using System.Linq;

namespace PotterKata1
{
    public static class PriceCalculator
    {
        private const double BaseBookPrice = 8.0;
        public static double CalculatePrice(params int [] books)
        {
            var price = BaseBookPrice * books.Length;
            var distinctBooks = books.Distinct().Count();
            var discount = GetDiscountFor(distinctBooks);

            return price * discount;
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