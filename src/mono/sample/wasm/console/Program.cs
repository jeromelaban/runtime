// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading.Tasks;
using System.Net.Http;

public class Test
{
    public static async Task<int> Main(string[] args)
    {
        await Task.Yield();
        Run();
        return 0;
    }

    static async void Run()
    {
        var client = new HttpClient();
        var r = await client.GetAsync("http://invalid.url");

        Console.WriteLine("test");
    }
}