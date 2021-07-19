using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TSSCodingChallenge.IntervalMerge
{
    public static class IntervalService
    {


        public static List<Tuple<int, int>> Merge(List<Tuple<int, int>> intervals)
        {


            // Sort intervals by first item
            intervals.Sort((x, y) => x.Item1.CompareTo(y.Item1));

            var mergedIntervals = new List<Tuple<int, int>>();

            for (int i = 0; i < intervals.Count; i++)
            {
                if (i == 0) mergedIntervals.Add(intervals[i]);
                else {

                    var previousInterval = mergedIntervals.Last();

                    // check if it intervals have to be merge
                    if (previousInterval.Item2 >= intervals[i].Item1)
                    {

                        var mergedInterval = new Tuple<int, int>(previousInterval.Item1, Math.Max(previousInterval.Item2,intervals[i].Item2));
                        mergedIntervals[mergedIntervals.Count()-1] = mergedInterval;
                    }
                    else
                    {
                        mergedIntervals.Add(intervals[i]);
                    }

                }
            }

            return mergedIntervals;
        }

        public static void PrintIntervals(List<Tuple<int, int>> intervals)
        {
            string output="";
            foreach(var interval in intervals)
            {
                output+=string.Format("[{0}, {1}]", interval.Item1, interval.Item2);
            }

            Console.WriteLine(output);
        }

        public static List<Tuple<int, int>> ValidateAndParseIntervalsString(string intervalsString)
        {
            // remove whitespaces
            string intervalsStringNoSpaces = Regex.Replace(intervalsString, @"\s+", "");

            var intervals = new List<Tuple<int, int>>();

            // split into intervalString
            foreach (Match intervalString in Regex.Matches(intervalsStringNoSpaces, @"\[(.+?)\]"))
            {
                try
                {
                    // The following code is not optimized! There's a better way to do it!

                    // remove brace [
                    string intervalsStringNoLeft = Regex.Replace(intervalString.Value, @"\[+", "");
                    // remove brace ]
                    string intervalsStringNoRight = Regex.Replace(intervalsStringNoLeft, @"\]+", "");
                    // split and convert into array
                    string[] namesArray = intervalsStringNoRight.Split(',');

                    int[] myInts = Array.ConvertAll(namesArray, s => int.Parse(s));

                    // throw error if interval is inverted
                    if(myInts[0]>myInts[1]) throw new Exception("No intervals found (Please check your input)");

                    var interval = new Tuple<int, int>(myInts[0], myInts[1]);

                    intervals.Add(interval);
                }
                catch
                {
                    throw new Exception("No intervals found (Please check your input)");
                }
            }

            if (intervals.Count == 0)
            {
                throw new Exception("No intervals found (Please check your input)");
            }

            return intervals;
        }

    }
}
