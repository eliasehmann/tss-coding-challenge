using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSSCodingChallenge.IntervalMerge.Tests
{
    [TestClass]
    public class ValidInputTest
    {

        [TestMethod]
        public void ValidInput()
        {
            var returnedIntevals = IntervalService.ValidateAndParseIntervalsString("[1,2] [3,4]");
            var expectedIntervals = new List<Tuple<int, int>>();
            expectedIntervals.Add(new Tuple<int, int>(1, 2));
            expectedIntervals.Add(new Tuple<int, int>(3, 4));
            CollectionAssert.AreEqual(returnedIntevals, expectedIntervals);
        }
    }
}
