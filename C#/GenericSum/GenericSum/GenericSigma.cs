using System;
using NUnit.Framework;

namespace GenericSum
{
    public  class GenericSigma
    {
        public T Sigma<T>(T start, T stop, Func<T, T> stepFunction, Func<T, T, int> order, Func<T, T, T> additionFunc)
        {
            var result = start;
            for (T i = stepFunction(start); order(i, stop) <= 0; i = stepFunction(i))
            {
                result = additionFunc(result, i);
            }
            return result;
        }
    }

    public class MyGenericSumExTests
    {
        [TestCase(1, 2, ExpectedResult = 3)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(-5, 2, ExpectedResult = -5 - 4 - 3 - 2 - 1 + 1 + 2)]
        public int SigmaIntegerTest(int start, int stop)
        {
            var sut = new GenericSigma();
            Func<int, int> stepFunction = (i => i + 1);
            Func<int, int, int> orderFunction = (x, y) => x.CompareTo(y);
            Func<int, int, int> additionFunction = (x, y) => x + y;
            return sut.Sigma(start, stop, stepFunction, orderFunction, additionFunction);
        }

        [TestCase(0.5, 2.5, 0.5 + 1.1 + 1.7 + 2.3)]
        public void SigmaDoubleTest(double start, double stop, double expectedResult)
        {
            var sut = new GenericSigma();
            Func<double, double> stepFunction = (i => i + 0.6);
            Func<double, double, int> orderFunction = (x, y) => x.CompareTo(y);
            Func<double, double, double> additionFunction = (x, y) => x + y;
            var result = sut.Sigma(start, stop, stepFunction, orderFunction, additionFunction);
            Assert.AreEqual(expectedResult, result, 0.0000000000001);
        }
    }
}
