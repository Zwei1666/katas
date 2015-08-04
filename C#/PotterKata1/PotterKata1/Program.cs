using NUnit.Framework;

namespace PotterKata1
{
    public class Basket
    {
        public static double CalculatePrice(params int [] books)
        {
            return 0.0;
        }
    }

    public class BasketTests
    {
        [Test]
        public void ShouldReturnUnmodifiedBasePriceForOneBook()
        {
           // Given
            var books = new[] {1};
            var expectedPrice = 8;

           // When
            var price = Basket.CalculatePrice(books);

            // Then
            Assert.AreEqual(expectedPrice, price);
        }
    }
}
