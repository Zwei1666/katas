namespace PotterKata1
{
    public static class PriceCalculator
    {
        private const double BaseBookPrice = 8.0;
        public static double CalculatePrice(params int [] books) => BaseBookPrice * books.Length;
    }
}