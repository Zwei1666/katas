using NUnit.Framework;

namespace PotterKata1
{
    public static class PriceCalculator
    {
        private const double BaseBookPrice = 8.0;
        public static double CalculatePrice(params int [] books) => BaseBookPrice * books.Length;
    }

    public class PriceCalculatorTests
    {
        [Test]
        public void ShouldReturnUnmodifiedBasePriceForOneBook()
        {
           // Given
            var books = new[] {1};
            var expectedPrice = 8.0;

           // When
            var price = PriceCalculator.CalculatePrice(books);

            // Then
            Assert.AreEqual(expectedPrice, price);
        }

        [Test]
        public void ShouldReturnUnmodifiedBasePriceForTwoSameBook()
        {
            // Given
            var books = new[] { 1, 1 };
            var expectedPrice = 16.0;

            // When
            var price = PriceCalculator.CalculatePrice(books);

            // Then
            Assert.AreEqual(expectedPrice, price);
        }
    }
}
