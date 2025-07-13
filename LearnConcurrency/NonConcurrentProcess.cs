using System.Diagnostics;

namespace LearnConcurrency;

internal class NonConcurrentProcess
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
        Console.WriteLine("Using synchronous requests");
        Stopwatch stopwatch = Stopwatch.StartNew();

        HttpClient client = new();
        foreach (string url in PageUrls)
        {
            var response = client.GetAsync(url).Result;
            Console.WriteLine($"Request to {url} returned {response.StatusCode}");
        }

        client.Dispose();

        stopwatch.Stop();
        double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
        Console.WriteLine($"Elapsed in {elapsedSeconds} seconds");
        Console.WriteLine("End synchronous requests example");
    }
}
