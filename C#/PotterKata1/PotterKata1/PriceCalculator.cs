using System.Linq;

namespace PotterKata1
{
    public static class PriceCalculator
    {
        private const double BaseBookPrice = 8.0;
        public static double CalculatePrice(params int [] books)
        {
            var price = BaseBookPrice * books.Length;
            if (books.Distinct().Count() > 1)
            {
                price *= 0.95;
            }

            return price;
        }
    }
}