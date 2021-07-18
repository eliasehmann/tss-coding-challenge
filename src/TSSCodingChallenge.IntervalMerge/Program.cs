using System;
using System.Collections.Generic;

namespace TSSCodingChallenge.IntervalMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            var intervals=IntervalService.ValidateAndParseIntervalsString(args[0]);
            var mergedIntervals = IntervalService.MergeAndSortIntervals(intervals);
            IntervalService.PrintIntervals(mergedIntervals);
        }
    }
}
