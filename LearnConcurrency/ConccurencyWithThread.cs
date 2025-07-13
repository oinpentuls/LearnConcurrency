using System.Diagnostics;

namespace LearnConcurrency;

internal class ConccurencyWithThread
{
    public List<string> PageUrls = [
        "https://www.scrapingcourse.com/ecommerce/page/1/",
        "https://www.scrapingcourse.com/ecommerce/page/2/",
        "https://www.scrapingcourse.com/ecommerce/page/3/",
        "https://www.scrapingcourse.com/ecommerce/page4/",
        "https://www.scrapingcourse.com/ecommerce/page5/"
    ];
    public void GetPages()
    {
        Console.WriteLine("Using threads");
        Stopwatch stopwatch = Stopwatch.StartNew();
        
        HttpClient client = new();
        List<Thread> threads = new();
        foreach (string url in PageUrls)
        {
            Thread thread = new(() =>
            {
                ProcessRequest(client, url);
            });
            threads.Add(thread);
        }

        foreach (Thread thread in threads)
        {
            thread.Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        client.Dispose();
        
        stopwatch.Stop();
        double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
        Console.WriteLine($"Elapsed in {elapsedSeconds} seconds");
        Console.WriteLine("End threads example");
    }

    private static void ProcessRequest(HttpClient client, string url)
    {
        var response = client.GetAsync(url).Result;
        Console.WriteLine($"Request to {url} returned {response.StatusCode}");
    }
}
