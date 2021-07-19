using System;
using System.Collections.Generic;

namespace TSSCodingChallenge.IntervalMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            try { 
            var intervals=IntervalService.ValidateAndParseIntervalsString(args[0]);
            var mergedIntervals = IntervalService.Merge(intervals);
            IntervalService.PrintIntervals(mergedIntervals);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
