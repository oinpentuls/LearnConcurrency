using LearnConcurrency;

NonConcurrentProcess nonConcurrentProcess = new();
nonConcurrentProcess.GetPages();

ConcurrentWithTask concurrentWithAsync = new();
await concurrentWithAsync.GetPages();

ConccurencyWithThread conccurencyWithThread = new();
conccurencyWithThread.GetPages();

ConcurrencyWithThreadPool concurrencyWithThreadPool = new();
concurrencyWithThreadPool.GetPages();

TaskContinuation taskContinuation = new();
taskContinuation.Run();