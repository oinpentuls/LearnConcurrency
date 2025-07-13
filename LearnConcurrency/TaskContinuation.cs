namespace LearnConcurrency;

internal class TaskContinuation
{
    public void Run()
    {
        Console.WriteLine("Using Task Continuation");
        Task<int> asyncTask = Task.Run(() =>
        {
            Console.WriteLine("Task started");
            Task.Delay(2000);
            Console.WriteLine("Task completed");
            return 42;
        });
        asyncTask.Wait();
        asyncTask.ContinueWith((completedTask) =>
        {
            Console.WriteLine("Continuation started");
            int result = completedTask.Result;
            Console.WriteLine($"Task Completed with Result: {result}");
        });

        Console.WriteLine("End Task Continuation example");
    }
}
