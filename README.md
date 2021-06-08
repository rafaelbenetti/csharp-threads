# csharp-threads
Learn how to use threads in c#.

## Threads 
 - Is a lower-level concept when you start a new one it will be a separeted thread.
 - Even using virtualization CPU core, at the end of the day, the threads are just running in the same single CPU core. 
 - Doesn't executes in the thread pool.
 - Each thread you have consumes an amount of memory for its stack.
 - And adds additional CPU overhead as the processor context-switch between threads.
 - Operations: you can Abort() or Suspend() or Resume()
 - Do not block threads! Because if you are using thread pool it is going to create more and more threads.
 
 ## Threads in background vs foreground
 - Background can be ignored at any point in time.
 - Foreground threads have the ability to prevent the current application from terminating..

## Context Switch
 - One CPU can run just one thing at time, it means that using multi-thread in a single core CPU is fake!!!
 - After quantum (approximately 30 mile seconds), Windows context switch to another thread.
 - Requires memory to manage all the threads and it means that your performance goes down depends on the situation. (For example with single core doesn't make sense to use it)
 - After switch, CPU suffers cache misses repopulating its cache.
	This really impacts the performance.

## CLR's Thread Pool
 - Manages thread creation for you.
 - The thread pool has threads for your application's use (initially 0) 
 - There is one thread pool per process, shared by all AppDomains.
 - The basics of TP is to take care of creation, management and when to destroy a thread. If you do not use TP you have to take care of it. Maybe it's not a good idea.

## Tasks
 - You can manage, get exception and also get a typed result.
 - With tasks, you have more control of your threads.

## Async and Await
 - Async: This keyword is used to qualify a function as an asynchronous function. In other words, if we specify the async keyword in front of a function then we can call this function asynchronously. Have a look at the syntax of the asynchronous method.

	```cs
	public async void CallProcess()
	{
	}
	```
 - Await: Very similar to wait, right? Yes this keyword is used when we want to call any function asynchronously. Have a look at the following example to understand how to use the await keyword. Let's think; in the following we have defined a long-running process.

	```cs
	public static Task LongProcess()
	{
		return Task.Run(() =>
		{
			System.Threading.Thread.Sleep(5000);
		});
	}
	```

 - Now, we want to call this long process asynchronously. Here we will use the await keyword.

	```cs
	await LongProcess();
	```
## TPL (Thread Parallel Library)
 - TPL Encapsulates multi-core execution.

## Parallel (For, Foreach, Invoke)
 - Used when you would like to run some parallel tasks and the order doesn't matter.
 - (For, Foreach and Invoke) All them runs in parallel changing just the sintax.

## Lock
 - The lock keyword ensures that one thread does not enter a critical section of code while another thread is in the critical section. If another thread tries to enter a locked code, it will wait, block, until the object is released.

 - The lock keyword calls Enter at the start of the block and Exit at the end of the block. lock keyword actually handles Monitor class at back end.

 	For example:

	```cs
	private static readonly Object objectToControlLock = new Object();

	lock (objectToControlLock)
	{
		// critical section
	}
	```	
	But, what really happens:
	
	```cs
	private static readonly Object objectToControlLock = new Object();
	private bool lockWasTaken = false;
	
	var temp = objectToControlLock;

	try
	{
		Monitor.Enter(temp, ref lockWasTaken);
		// critical section
	}
	finally
	{
		if (lockWasTaken)
		{
			Monitor.Exit(temp); 
		}
	}
	```

	You can lock "this" object using this attribute. (It is bad lock using this)

	```cs
	class BathRoomStall 
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void BeUsed()
		{
			Console.WriteLine("Doing our thing...");
			Thread.Sleep(2000);
		}
	}
	```
## Lock Conclusions
 - You must lock the Danger Zone.
 - You must encapsulate the locks into a class to prevent programmers mistakes.
 - It is a bad idea use this in the lock. Example use the same class as the object to lock.
 - IMPORTANT - If you have two methods using the same object for lock, remember that it are goint to wait one method complete to go to the second method.

## Mutex
 - They can be accessed from multiple processes. 
 - [Named] It is eligible to be a system-wide Mutex that can be accessed from multiple processes.
 - [Unnamed] It is an anonymous Mutex which can only be accessed within the process in which it is created.
 - WaitOne method returns true for free critical section and false for busy critical section.
 - ReleaseMutex release the critical code.

```c
private readonly Mutex mutex = new Mutex(false, "NamedMutex");
public void ThreadSafeMethod() {
    mutex.WaitOne();
    try {
        /* critical code */
    } 
    finally {
        mutex.ReleaseMutex();
    }
}
 ```

## Semaphore
 - They can be named an unnamed just as mutex.
 - A semaphore does the same as a mutex but allows x number of threads to enter.
 
 ```c
 Semaphore semaphoreObject = new Semaphore(initialCount: 0, maximumCount: 5, name: "MyUniqueNameApp");

 semaphoreObject.WaitOne();
 Console.WriteLine("Doing some stuff");
 semaphoreObject.Release();
 ```

## Race Conditions
 - Many resources trying to access the Danger Zone at the same time.
 - It occurs using multi-tread.

## Deadlock
 - A lock occurs when multiple processes try to access the same resource at the same time.
    - One process loses out and must wait for the other to finish.  
 - Is a state in which each member of a group of actions is waiting for some other member to release a lock.
 - A deadlock occurs when the waiting process is still holding on to another resource that the first needs before it can finish.
 - A is waiting for B release a resource and B is waiting for A release a resource.
 - [Prevent] Reduce the need to lock anything as much as you can.

## Danger Zone (Critical Section)
 - It is the code that cannot be shared with two threads.

## TLS (Thread Location Storage)
 - Is a computer programming method that uses static or global memory local to a thread.

## Timer
 - It's better to create Timers rather Threads to execute something in some interval.
 - Do not let your threads sleep, always it's a bad idea.

# CSharp Commands

 - Get Logical Processors
	```cs
	Environment.ProcessorCount
	```

 - Set number of Logical Processors
	```cs
	int numberOfProcessors = 4;
    Process.GetCurrentProcess().ProcessorAffinity = (IntPtr)numberOfProcessors;
	```

- Get Thread Id
	```cs
	Thread.CurrentThread.ManagedThreadId
	```

# CSharp Concepts

## CLR (Common Language Runtime)
 - The .NET Framework provides a run-time environment called the common language runtime, which runs the code and provides services that make the development process easier.

## Garbage Collector
 - Identify process that can be destroyed and clean it. It helps the memory usage.

## Delegate
 - Delegates allow methods to be passed as parameters.
 - Delegates can be used to define callback methods.
 - Delegates can be chained together; for example, multiple methods can be called on a single event.

 # References

 - [Threads - Beginner Guide](http://www.mono-project.com/archived/threadsbeginnersguide/)