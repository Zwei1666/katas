using System;
using System.Linq;
using System.Xml;
using FsCheck;
using NUnit.Framework;

namespace KarateChop1
{
    //chop(int, array_of_int)  -> int

    public interface IKarateChoper
    {
        /// <summary>
        /// Seeks for target in collection. It returns zero based index of position if it finds the target in collection. If it does not find target in collection it returens -1.
        /// </summary>
        /// <param name="target"> element to seek in colection </param>
        /// <param name="collection"> collection of elements to seek in</param>
        /// <returns> Position of target in colletion or -1 if target is not present in collection </returns>
        int Chop(int target, int[] collection);
    }

    public class KarateChoper : IKarateChoper
    {
        public int Chop(int target, int[] collection)
        {
            return collection.Length == 0 ? -1 : BinarySearch(target, 0, collection.Length - 1, collection);
        }

        private static int BinarySearch(int target, int start, int stop, int[] collection)
        {
            if (start == stop)
            {
                return target == collection[start]? start : -1;
            }

            var middle = start + (stop - start)/2;

            if (collection[middle] > target)
            {
                return BinarySearch(target, start, middle - 1, collection);
            }
            if (collection[middle] < target)
            {
                return BinarySearch(target, middle + 1, stop, collection);
            }

            return middle;
        }
    }

    public class KarateChoperTests
    {
        private readonly KarateChoper _sut = new KarateChoper();

        [Test]
        [TestCase(0, 1,2,3, ExpectedResult = -1)]
        [TestCase(4, 1,2,3, ExpectedResult = -1)]
        [TestCase(5, 1,2,3, ExpectedResult = -1)]
        [TestCase(1, ExpectedResult = -1)]
        [TestCase(0, ExpectedResult = -1)]
        public int ShouldReturnMinusOneForElementsNotPresentInCollection(int target, params int[] collection) => _sut.Chop(target, collection);

        [Test]
        //Odd number of elements in collection
        [TestCase(1, 1, 2, 3, ExpectedResult = 0)]
        [TestCase(2, 1, 2, 3, ExpectedResult = 1)]
        [TestCase(3, 1, 2, 3, ExpectedResult = 2)]
        //Even number of elements in collection
        [TestCase(1, 1, 2, 3, 4, ExpectedResult = 0)]
        [TestCase(2, 1, 2, 3, 4, ExpectedResult = 1)]
        [TestCase(3, 1, 2, 3, 4, ExpectedResult = 2)]
        [TestCase(4, 1, 2, 3, 4, ExpectedResult = 3)]

        [TestCase(22, 22, 44, 45, ExpectedResult = 0)]
        public int ShouldReturnThePositionOfElementForElementsPresentInCollection(int target, params int[] collection) => _sut.Chop(target, collection);
    }

    public class KarateChoperPropertyTests
    {
        private readonly System.Random _rand = new System.Random();
        private readonly KarateChoper _sut = new KarateChoper();

        [Test]
        public void RandomTests()
        {
            Prop.ForAll((Func<int[], bool>) (xs =>
            {
                if (!xs.Any())
                    return true;
                Array.Sort(xs);

                var startposition = _rand.Next(0, xs.Length);
                var target = xs.ElementAt(startposition);
                var position = Array.IndexOf(xs, target);
                var result = _sut.Chop(target, xs);
                if (result != position)
                {
                    Console.WriteLine($"target: {target} position:{position} resukt:{result}");
                }
                return result == position;
            })).QuickCheckThrowOnFailure();
        }
    }

}
