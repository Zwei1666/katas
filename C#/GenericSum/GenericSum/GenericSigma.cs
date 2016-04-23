using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace GenericSum
{
    public  class GenericSigma
    {
        public T Sigma<T>(T start, T stop, Func<T> seedFunction, Func<T, T, int> order, Func<T, T> stepFunction, Func<T, T, T> additionFunc)
        {
            T result = seedFunction();
            for (T i = start; order(i, stop) <= 0; i = stepFunction(i))
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
            Func<int, int> stepFunction = i => i + 1;
            Func<int, int, int> orderFunction = (x, y) => x.CompareTo(y);
            Func<int, int, int> additionFunction = (x, y) => x + y;
            return sut.Sigma(start, stop, () => 0, orderFunction, stepFunction, additionFunction);
        }

        [TestCase(0.5, 2.5, 0.5 + 1.1 + 1.7 + 2.3)]
        public void SigmaDoubleTest(double start, double stop, double expectedResult)
        {
            var sut = new GenericSigma();
            Func<double, double> stepFunction = i => i + 0.6;
            Func<double, double, int> orderFunction = (x, y) => x.CompareTo(y);
            Func<double, double, double> additionFunction = (x, y) => x + y;
            var result = sut.Sigma(start, stop, () => 0.0, orderFunction, stepFunction, additionFunction);
            Assert.AreEqual(expectedResult, result, 0.0000000000001);
        }

        public class BoxedInt
        {
            private int _x;

            public BoxedInt() : this(default(int))
            {
                
            }
            public BoxedInt(int x)
            {
                _x = x;
            }

            public static BoxedInt operator +(BoxedInt a, BoxedInt b) => new BoxedInt(a._x+b._x);

            public int CompareTo(BoxedInt other) => _x.CompareTo(other._x);
        }

        [Test]
        public void ShouldAlwaysReturnNewObject()
        {
            var sut = new GenericSigma();
            Func<BoxedInt, BoxedInt> stepFunction = i => i + new BoxedInt(1);
            Func<BoxedInt, BoxedInt, int> orderFunction = (x, y) => x.CompareTo(y);
            Func<BoxedInt, BoxedInt, BoxedInt> additionFunction = (x, y) => x + y;
            BoxedInt start = new BoxedInt(0);
            BoxedInt stop = new BoxedInt(0);
            var result = sut.Sigma(start, stop, () => new BoxedInt(), orderFunction, stepFunction, additionFunction);
            Assert.AreNotSame(start, result, "is same as start");
            Assert.AreNotSame(stop, result, " is same as stop");
        }
    }
}
