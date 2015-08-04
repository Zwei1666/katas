using System.Linq;

namespace PotterKata1
{
    public static class PriceCalculator
    {
        private const double BaseBookPrice = 8.0;
        public static double CalculatePrice(params int [] books)
        {
            return BaseBookPrice * books.Length * (books.Distinct().Count() >1?0.95:1);
        }
    }
}