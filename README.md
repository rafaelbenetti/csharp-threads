# csharp-threads
Learn how to use threads in c#.

Threads: 
 - Even using virtualization CPU core, at the end of the day, the threads are just running in the same single CPU core.
 - Threads allocates a bit more of memory. 
 - Do not block threads! Because if you are using thread pool it is going to create more and more threads.
 
TLS (Thread Location Storage)
 - TODO

Context Switch
 - One CPU can run just one thing at time, it means that using multi-thread in a single core CPU is fake!!!
 - After quantum (approximately 30 mile seconds), Windows context switch to another thread.
 - Requires memory to manage all the threads and it means that your performance goes down depends on the situation. (For example with single core doesn't make sense to use it)
 - After switch, CPU suffers cache misses repopulating its cache.
	This really impacts the performance.

CLR's Thread Pool
 - Manages thread creation for you.
 - The thread pool has threads for your application's use (initially 0) 
 - There is one thread pool per process, shared by all AppDomains.
 - The basics of TP is to take care of creation, management and when to destroy a thread. If you do not use TP you have to take care of it. Maybe it's not a good idea.

Tasks
 - You can manage, get exception and also get a typed result.
 - With tasks, you have more control of your threads.

Parallel (For, Foreach, Invoke)
 - Used when you would like to run some parallel tasks and the order doesn't matter.

Timer
 - It's better to create Timers rather Threads to execute something in some interval.
 - Do not let your threads sleep, always it's a bad idea.

Garbage Collector
 - Identify process that can be destroyed and clean it. It helps the memory usage.

Delegate
 - TODO