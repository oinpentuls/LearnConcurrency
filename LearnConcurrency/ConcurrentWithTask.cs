using System.Diagnostics;

namespace LearnConcurrency;

internal class ConcurrentWithTask
{
    public List<string> PageUrls = [
        "https://www.scrapingcourse.com/ecommerce/page/1/",
        "https://www.scrapingcourse.com/ecommerce/page/2/",
        "https://www.scrapingcourse.com/ecommerce/page/3/",
        "https://www.scrapingcourse.com/ecommerce/page4/",
        "https://www.scrapingcourse.com/ecommerce/page5/"
        ];

    public async Task GetPages()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        Console.WriteLine("Using Task");

        HttpClient client = new();

        // intialize a list of tasks
        List<Task> tasks = new();
        foreach (string url in PageUrls)
        {
            tasks.Add(Task.Run(() => ProcessRequest(client, url)));
        }

        await Task.WhenAll(tasks);

        client.Dispose();

        stopwatch.Stop();
        double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
        Console.WriteLine($"Elapsed in {elapsedSeconds} seconds");
        Console.WriteLine("End Task example");
    }

    private void ProcessRequest(HttpClient client, string url)
    {
        var response = client.GetAsync(url).Result;
        Console.WriteLine($"Request to {url} returned {response.StatusCode}");
    }
}
