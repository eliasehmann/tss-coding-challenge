using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TSSCodingChallenge.IntervalMerge;

namespace TSSCodingChallenge.ItervalMerge.Tests
{
    [TestClass]
    public class InvalidInputTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "No intervals found (Please check your input)")]
        public void RandomInput()
        {
            IntervalService.ValidateAndParseIntervalsString("foo");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "No intervals found (Please check your input)")]
        public void RandomInput2()
        {
            IntervalService.ValidateAndParseIntervalsString("[a,2] asdasd");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "No intervals found (Please check your input)")]
        public void NoInput()
        {
            IntervalService.ValidateAndParseIntervalsString("");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "No intervals found (Please check your input)")]
        public void TypeNotMatchingInput()
        {
            var intervals = IntervalService.ValidateAndParseIntervalsString("[asd,asd]");
            Console.WriteLine(intervals.ToString());
        }


    }
}
