// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Uno.Gallery.Wasm
{
    public class Test
    {
        public static async Task<int> Main(string[] args)
        {
            Console.WriteLine("start");
            await Task.Delay(1);

            var categories = App.GetSamples()
                .OrderByDescending(x => x.SortOrder.HasValue)
                .ThenBy(x => x.SortOrder)
                .ThenBy(x => x.Title)
                .GroupBy(x => x.Category)
                .OrderBy(x => x.Key)
                .ToArray();

             Console.WriteLine("end " + categories.Length);
           return args.Length;
        }
    }
}