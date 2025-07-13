# LearnConcurrency

Macam2 cara concurrency menggunakan `Thread` dan `Task`.

Selanjut nya belajar Parallelism menggunakan [TPL](https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/data-parallelism-task-parallel-library)
di repo yang lain

sumber artikel [Belajar Konkurensi](https://www.zenrows.com/blog/concurrency-c-sharp)
```sh
Using synchronous requests
Request to https://www.scrapingcourse.com/ecommerce/page/1/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page/2/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page/3/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page4/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page5/ returned OK
Elapsed in 4,9916085 seconds
End synchronous requests example
Using Task
Request to https://www.scrapingcourse.com/ecommerce/page/2/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page/3/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page/1/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page4/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page5/ returned OK
Elapsed in 1,5044917 seconds
End Task example
Using threads
Request to https://www.scrapingcourse.com/ecommerce/page/3/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page/2/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page/1/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page4/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page5/ returned OK
Elapsed in 1,6003603 seconds
End threads example
Using ThreadPool
Request to https://www.scrapingcourse.com/ecommerce/page/3/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page/2/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page/1/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page5/ returned OK
Request to https://www.scrapingcourse.com/ecommerce/page4/ returned OK
Elapsed in 1,4602946 seconds
End ThreadPool example
Using Task Continuation
Task started
Task completed
End Task Continuation example
Continuation started
Task Completed with Result: 42
```
