using NUnit.Framework;

namespace PotterKata1
{
    public class PriceCalculator
    {
        public static double CalculatePrice(params int [] books) => 8.0;
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
