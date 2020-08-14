using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'countMeetings' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY firstDay
     *  2. INTEGER_ARRAY lastDay
     */

    public static int countMeetings(List<int> firstDay, List<int> lastDay)
    {
        int numOfInvestors = firstDay.Count();
        int startDay = firstDay.Min();
        int endDay = lastDay.Max();
        List<int> scheduledMeetings = new List<int>();

        Dictionary<int, int> firstDayDict = new Dictionary<int, int>();
        Dictionary<int, int> lastDayDict = new Dictionary<int, int>();

        for (int j = 0; j < numOfInvestors; j++)
        {
            firstDayDict.Add(j, firstDay[j]);
            lastDayDict.Add(j, lastDay[j]);
        }

        var sortedLastDayDict = (from entry in lastDayDict orderby entry.Value ascending select entry.Key).ToList();


        List<int> newFirstDay = new List<int>();
        List<int> newLastDay = new List<int>();

        for (int k = 0; k < sortedLastDayDict.Count(); k++)
        {
            int index = sortedLastDayDict[k];
            newFirstDay.Add(firstDay[index]);
            newLastDay.Add(lastDay[index]);
        }

        int i = 0;

        while (startDay <= endDay)
        {

            if (startDay >= newFirstDay[i] && startDay <= newLastDay[i])
            {
                scheduledMeetings.Add(1);
            }
            i++;
            startDay++;
            if (i == numOfInvestors)
            {
                i = i % numOfInvestors;
            }
            if (scheduledMeetings.Count() == numOfInvestors)
            {
                break;
            }
        }

        return scheduledMeetings.Count();

    }
}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int firstDayCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> firstDay = new List<int>();

        for (int i = 0; i < firstDayCount; i++)
        {
            int firstDayItem = Convert.ToInt32(Console.ReadLine().Trim());
            firstDay.Add(firstDayItem);
        }

        int lastDayCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> lastDay = new List<int>();

        for (int i = 0; i < lastDayCount; i++)
        {
            int lastDayItem = Convert.ToInt32(Console.ReadLine().Trim());
            lastDay.Add(lastDayItem);
        }

        int result = Result.countMeetings(firstDay, lastDay);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
