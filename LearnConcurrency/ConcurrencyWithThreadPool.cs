using System.Diagnostics;

namespace LearnConcurrency;

internal class ConcurrencyWithThreadPool
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
        Console.WriteLine("Using ThreadPool");
        Stopwatch stopwatch = Stopwatch.StartNew();
        
        HttpClient client = new();
        CountdownEvent countdown = new(PageUrls.Count);
        
        foreach (string url in PageUrls)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                ProcessRequest(client, url);

                countdown.Signal(); // Signal that this request is complete
            });
        }

        countdown.Wait(); // Wait for all requests to complete

        client.Dispose();
        stopwatch.Stop();
        double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
        Console.WriteLine($"Elapsed in {elapsedSeconds} seconds");
        Console.WriteLine("End ThreadPool example");
    }
    private static void ProcessRequest(HttpClient client, string url)
    {
        var response = client.GetAsync(url).Result;
        Console.WriteLine($"Request to {url} returned {response.StatusCode}");
    }
}
