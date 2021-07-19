using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TSSCodingChallenge.IntervalMerge;

namespace TSSCodingChallenge.ItervalMerge.Tests
{
    [TestClass]
    public class SortAndMergeTest
    {
        [TestMethod]
        public void RandomInput()
        {

            var input = new List<Tuple<int, int>>();
            input.Add(new Tuple<int, int>(2, 4));
            input.Add(new Tuple<int, int>(3, 4));
            input.Add(new Tuple<int, int>(1, 4));
            input.Add(new Tuple<int, int>(89, 92));
            input.Add(new Tuple<int, int>(5, 9));
            var returnedIntevals = IntervalService.Merge(input);

            var expectedIntervals= new List<Tuple<int, int>>();
            expectedIntervals.Add(new Tuple<int, int>(1, 4));
            expectedIntervals.Add(new Tuple<int, int>(5, 9));
            expectedIntervals.Add(new Tuple<int, int>(89, 92));


            CollectionAssert.AreEqual(returnedIntevals, expectedIntervals);
        }

        [TestMethod]
        public void RandomInput2()
        {

            var input = new List<Tuple<int, int>>();
            input.Add(new Tuple<int, int>(0, 9));
            input.Add(new Tuple<int, int>(99, 100));
            input.Add(new Tuple<int, int>(5, 20));
            input.Add(new Tuple<int, int>(89, 92));
            input.Add(new Tuple<int, int>(11, 59));
            var returnedIntevals = IntervalService.Merge(input);

            var expectedIntervals = new List<Tuple<int, int>>();
            expectedIntervals.Add(new Tuple<int, int>(0, 59));
            expectedIntervals.Add(new Tuple<int, int>(89, 92));
            expectedIntervals.Add(new Tuple<int, int>(99, 100));


            CollectionAssert.AreEqual(returnedIntevals, expectedIntervals);
        }

    }
}
