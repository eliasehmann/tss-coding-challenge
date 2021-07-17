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


        public static List<Tuple<int, int>> MergeAndSortIntervals(List<Tuple<int, int>> intervals)
        {
            throw new NotImplementedException();
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
                    // The following code is not optimized! There's a better way to do it

                    // remove brace [
                    string intervalsStringNoLeft = Regex.Replace(intervalString.Value, @"\[+", "");
                    // remove brace ]
                    string intervalsStringNoRight = Regex.Replace(intervalsStringNoLeft, @"\]+", "");
                    // split and convert into array
                    string[] namesArray = intervalsStringNoRight.Split(',');

                    int[] myInts = Array.ConvertAll(namesArray, s => int.Parse(s));

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
            Console.WriteLine(intervals.ToString());



            return intervals;
        }

    }
}
