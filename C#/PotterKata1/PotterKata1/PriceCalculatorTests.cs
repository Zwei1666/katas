using NUnit.Framework;

namespace PotterKata1
{
    public class PriceCalculatorTests
    {
        [TestCase(8.0, new []{1})]
        [TestCase(16.0, 1,1)]
        [TestCase(16*0.95, 1,2)]
        public void ShouldReturnProperPriceForVariousCombinationsOfBooks(double expectedPrice, params int [] books)
        {
           // When
            var price = PriceCalculator.CalculatePrice(books);

            // Then
            Assert.AreEqual(expectedPrice, price);
        }
    }
}
