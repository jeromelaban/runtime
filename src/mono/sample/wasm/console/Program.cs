// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

public class Test
{
    public static async Task<int> Main(string[] args)
    {
        await Task.Delay(1);
        TestEnumeratorListOfT();
        TestForeachListOfT();
        TestForListOfT();
        TestForArray();

        return 0;
    }

    private static void TestForArray()
    {
        var SUT = new List<object>();
        SUT.AddRange(Enumerable.Range(1, 1000)
            .Select(i => (object)null));
        var SUT2 = SUT.ToArray();

        var sw = Stopwatch.StartNew();

        for (int i = 0; i < 5000; i++)
        {
            int count = 0;
            foreach (var item in SUT2)
            {
                count++;
            }
        }

        sw.Stop();
        Console.WriteLine($"TestForArray: {sw.Elapsed}");
    }


    private static void TestForListOfT()
    {
        var SUT = new List<object>();
        SUT.AddRange(Enumerable.Range(1, 1000)
            .Select(i => (object)null));

        var sw = Stopwatch.StartNew();

        for (int j = 0; j < 5000; j++)
        {
            int count = 0;
            for (int i = 0; i < SUT.Count; i++)
            {
                var r = SUT[i];
                count++;
            }
        }

        sw.Stop();
        Console.WriteLine($"TestForListOfT: {sw.Elapsed}");
    }

    private static void TestForeachListOfT()
    {
        var SUT = new List<object>();
        SUT.AddRange(Enumerable.Range(1, 1000)
            .Select(i => (object)null));

        var sw = Stopwatch.StartNew();

        for (int i = 0; i < 5000; i++)
        {
            int count = 0;
            foreach (var item in SUT)
            {
                count++;
            }
        }

        sw.Stop();
        Console.WriteLine($"TestForeachListOfT: {sw.Elapsed}");
    }

    private static void TestEnumeratorListOfT()
    {
        var SUT = new List<object>();
        SUT.AddRange(Enumerable.Range(1, 1000)
            .Select(i => (object)null));

        var sw = Stopwatch.StartNew();

        for (int i = 0; i < 5000; i++)
        {
            int count = 0;
            var enumerator = SUT.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var r = enumerator.Current;
                count++;
            }
        }

        sw.Stop();
        Console.WriteLine($"TestEnumeratorListOfT: {sw.Elapsed}");
    }
}