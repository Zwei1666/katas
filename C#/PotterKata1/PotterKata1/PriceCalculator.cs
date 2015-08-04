using System.Linq;

namespace PotterKata1
{
    public static class PriceCalculator
    {
        private const double BaseBookPrice = 8.0;
        public static double CalculatePrice(params int [] books)
        {
            var price = BaseBookPrice * books.Length;
            switch(books.Distinct().Count())
            {
                case 2:
                    price *= 0.95;
                    break;
                case 3:
                    price *= 0.9;
                    break;
                case 4:
                    price *= 0.8;
                    break;
                case 5:
                    price *= 0.75;
                    break;
            }

            return price;
        }
    }
}