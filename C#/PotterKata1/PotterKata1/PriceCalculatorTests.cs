using NUnit.Framework;

namespace PotterKata1
{
    public class PriceCalculatorTests
    {
        [TestCase(8.0, new []{1})]
        [TestCase(16.0, 1, 1)]
        [TestCase(2*8*0.95, 1, 2)]
        [TestCase(3*8*0.9, 1, 2, 3)]
        [TestCase(4*8*0.8, 1, 2, 3, 4)]
        [TestCase(5*8*0.75, 1, 2, 3, 4, 5)]
        [TestCase(5*8*0.75 + 8, 1, 2, 3, 4, 5, 5)]
        public void ShouldReturnProperPriceForVariousCombinationsOfBooks(double expectedPrice, params int [] books)
        {
           // When
            var price = PriceCalculator.CalculatePrice(books);

            // Then
            Assert.AreEqual(expectedPrice, price);
        }
    }
}
